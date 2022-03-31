using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintAndCrouch : MonoBehaviour
{
    // Start is called before the first frame update

    private PlayerMove playerMovement;

    public float Sprint_Speed = 10f;
    public float move_speed = 5f;

    public float crouch_Speed = 2f;

    private Transform Look_Root;

    private float stand_height = 1.6f;

    private float crouch_height = 1f;

    private bool is_crouching;

    private PlayerFootSteps player_footsteps;

    private float sprint_volume = 1f;

    private float crouch__volume = 0.1f;

    private float walk_volume_min = 0.2f, walk_volume_max = 0.6f;

    private float Walk_step_Distance = 0.4f;

    private float Sprint_step_Distance = 0.25f;

    private float Crouch_step_Distance = 0.5f;
    private PlayerStats player_Stats;
    private float sprint_Value=100f;
    public float sprint_Treshold=10f;


    void Awake()
    {
        playerMovement = GetComponent<PlayerMove>();

        Look_Root = transform.GetChild(0);

        player_footsteps = GetComponentInChildren<PlayerFootSteps>();
        player_Stats=GetComponent<PlayerStats>();
    }

    void Start() 
    {
        player_footsteps.volume_Min = walk_volume_min;
        player_footsteps.volume_Max = walk_volume_max;
        player_footsteps.step_Distance = Walk_step_Distance;


    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {
        //if we have stamina we can sprint
        if(sprint_Value>0f)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift) && !is_crouching)
        {
            playerMovement.speed = Sprint_Speed;

            player_footsteps.step_Distance = Sprint_step_Distance;

            player_footsteps.volume_Min = sprint_volume;

            player_footsteps.volume_Max = sprint_volume;
            
        }
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) && !is_crouching)
        {
            playerMovement.speed = move_speed; // 5 = 5

            player_footsteps.step_Distance = Walk_step_Distance;
            player_footsteps.volume_Min = walk_volume_min;
            player_footsteps.volume_Max = walk_volume_max;
            
        }
        if(Input.GetKey(KeyCode.LeftShift)&& !is_crouching)
        {
            sprint_Value-=sprint_Treshold*Time.deltaTime;
            if(sprint_Value<=0f)
            {
                sprint_Value=0f;
                //resst the speed and sound
                playerMovement.speed=move_speed;
                player_footsteps.step_Distance = Walk_step_Distance;
                player_footsteps.volume_Min = walk_volume_min;
                player_footsteps.volume_Max = walk_volume_max;
            }
            player_Stats.Display_StaminaStats(sprint_Value);

        } else{
            if(sprint_Value !=100f){
                sprint_Value +=(sprint_Treshold/2f)*Time.deltaTime;
                player_Stats.Display_StaminaStats(sprint_Value);
                if(sprint_Value>100f) {
                    sprint_Value=100f; 
                }
            }
        }
    }//sprint

    void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            // if we are crouching standup
            if(is_crouching)
            {
                Look_Root.localPosition = new Vector3(0f, stand_height, 0f);
                playerMovement.speed = move_speed;

                player_footsteps.step_Distance = Walk_step_Distance;
                player_footsteps.volume_Min = walk_volume_min;
                player_footsteps.volume_Max = walk_volume_max;
                is_crouching = false; // we stand up

            }
            else // if we are not crouching crouch up
            {
                Look_Root.localPosition = new Vector3(0f, crouch_height, 0f);
                playerMovement.speed = crouch_Speed;

                player_footsteps.step_Distance = Crouch_step_Distance;

                player_footsteps.volume_Min = crouch__volume;
                player_footsteps.volume_Max = crouch__volume;
                is_crouching = true; // we stand up
            }

        }// if we can crouch if we press c

    }
}// class













