using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

  public enum EnemyState
    {
        PATROL,
        CHASE,
        ATTACK
    }
public class EnemyController : MonoBehaviour
{
    private EnemyAnimator enemy_anim;
    private NavMeshAgent navagent;

    private EnemyState enemy_state;


    public float Walk_speed = 0.5f;
    public float run_speed = 4f;

    public float Chase_Distance = 7f;

    private float current_chase_Distance;

    public float attack_Distance = 1.8f;
    
    public float Chase_after_Attack_distance = 2f;

    public float patrol_Raius_Min = 20f, patrol_Raius_Max = 60f;

    public float patrol_For_This_Time = 15f;

    private float patrol_Timer;

    public float wait_Before_Attack = 2f;

    private float attack_timer;


    private Transform target;

    public GameObject attack_point;

    private EnemyAudio enemy_audio;


    private void Awake() {
        enemy_anim = GetComponent<EnemyAnimator>();
        navagent = GetComponent<NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;

        enemy_audio = GetComponentInChildren<EnemyAudio>();


    } 

  
    void Start()
    {
        enemy_state = EnemyState.PATROL;

        patrol_Timer = patrol_For_This_Time;

        //when emeny first gets to player
        //Attack RighAway
        attack_timer = wait_Before_Attack;

        //Memorize the value of chase distace so we can put it back
        current_chase_Distance = Chase_Distance;
    }

    // Update is called once per frame
    void Update()
    {

        if(enemy_state == EnemyState.PATROL)
        {
            Patrol();
        }
        if(enemy_state == EnemyState.CHASE)
        {
            Chase();
        }
        if(enemy_state == EnemyState.ATTACK)
        {
            Attack();
        }
        
    }

    void Patrol()
    {
        //tell navAgent HE can Move
        navagent.isStopped = false;

        navagent.speed = Walk_speed;

        patrol_Timer += Time.deltaTime;

        if(patrol_Timer > patrol_For_This_Time)
        {
            SetNewRandomDestination();
            patrol_Timer = 0f;
        }

        if(navagent.velocity.sqrMagnitude > 0) // means we are moving
        {
            enemy_anim.Walk(true);

        }
        else
        {
            enemy_anim.Walk(false);
        }

        ///test the distance between player and the enemy
        if(Vector3.Distance(transform.position, target.position) <= Chase_Distance)
        {
            enemy_anim.Walk(false);
            enemy_state = EnemyState.CHASE;

            //play spotted Audio && // Also Play animation of zombie scream
            enemy_audio.Play_ScreamSound();


        }


    }//Patrol

    void Chase()
    {

        navagent.isStopped = false;

        navagent.speed = run_speed;

        navagent.SetDestination(target.position); //Running Towards the player

        if(navagent.velocity.sqrMagnitude > 0) // means we are moving
        {
            enemy_anim.Run(true);

        }
        else
        {
            enemy_anim.Run(false);
        }

        //If the Distance between Enemy and  Player is less than the Attack Distance
        if(Vector3.Distance(transform.position, target.position) <= attack_Distance)
        {
            //stopthe Animations
            enemy_anim.Walk(false);
            enemy_anim.Run(false);
            enemy_state = EnemyState.ATTACK;

            // rests the chase distace to previous
            if(Chase_Distance != current_chase_Distance)
            {
                Chase_Distance = current_chase_Distance;
            }
        }
        else if(Vector3.Distance(transform.position, target.position) >= Chase_Distance)
        {
            // player run away from enemy
            //stop running 

            enemy_anim.Run(false);
            enemy_state = EnemyState.PATROL;
            
            //reset the patrol timer so that the function
            // can calculate the par=trol destination
            patrol_Timer = patrol_For_This_Time;

            if(Chase_Distance != current_chase_Distance)
            {
                Chase_Distance = current_chase_Distance;
            }
        }


    }//Chase


    void Attack()
    {
        navagent.velocity = Vector3.zero;
        navagent.isStopped = true;

        attack_timer += Time.deltaTime;

        if(attack_timer > wait_Before_Attack)
        {
            enemy_anim.Attack();
            attack_timer = 0f;

            //PLay attack Sound
            enemy_audio.PlayAttackSound();

        }
        if(Vector3.Distance(transform.position, target.position) > attack_Distance + Chase_after_Attack_distance)
        {
            enemy_state = EnemyState.CHASE;

        }

    }
    void SetNewRandomDestination()
    {
        float rand_radius = Random.Range(patrol_Raius_Min, patrol_Raius_Max);

        Vector3 randDir = Random.insideUnitSphere * rand_radius;

        randDir += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDir, out navHit, rand_radius, -1);

        navagent.SetDestination(navHit.position);
    }

     void Turn_on_AttackPoint()
    {
        attack_point.SetActive(true);
    }

    void Turn_off_AttackPoint()
    {
        if(attack_point.activeInHierarchy)
        {
            attack_point.SetActive(false);
        }
    }


    public EnemyState enemy_State
    {
        get; set;
    }
}
