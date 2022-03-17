using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update

    private EnemyAnimator enemy_anim;

    private NavMeshAgent Nav_agent;

    private EnemyController enemyController;



    public float Health = 100f;

    public bool is_player, is_Jill;

    private bool is_Dead;


    void Awake()
    {

        if(is_Jill)
        {
            enemy_anim = GetComponent<EnemyAnimator>();
            enemyController = GetComponent<EnemyController>();
            Nav_agent = GetComponent<NavMeshAgent>();

            //get the enemy audio

        }

        if(is_player)
        {

        }


        
    }

    // Update is called once per frame

    public void ApplyDamage(float Damage)
    {
        // if we die dont execute the code
        if(is_Dead)
        {
            return;
        }


        Health -= Damage;

        if(is_player) 
        {
            // display the health ui value
        }

        if(is_Jill)
        {
            if(enemyController.enemy_State == EnemyState.PATROL)
            {
                enemyController.Chase_Distance = 50f; // chase distance to higher value so he knows where player is
            }

         
        }

        if(Health <= 0f)
        {
            PlayerDied();
            is_Dead = true;
            
        }

     
    }


    void PlayerDied()
    {

        if(is_Jill)
        {
            Nav_agent.velocity = Vector3.zero;
            Nav_agent.isStopped = true;
            enemyController.enabled = false;
            enemy_anim.Dead();
        }

        if(is_player)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);

            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }
            //call enemy manaager to stop spawning enemies

            GetComponent<PlayerMove>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
        }

        if(tag == Tags.PLAYER_TAG)
        {
            Invoke("RestartGame", 3f);
        }
        else
        {
            Invoke("TurnOffGameObject", 4f);
        }
       

    }//PlayerDied

    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_A");
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
}