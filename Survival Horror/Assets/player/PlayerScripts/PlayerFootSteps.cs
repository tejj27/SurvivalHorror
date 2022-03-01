using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    private AudioSource FootStepSound;

    [SerializeField]
    private AudioClip[] footstepclip;

    private CharacterController character_controller;

    [HideInInspector]
    public float volume_Min, volume_Max;

    private float accumulated_Distance;

    [HideInInspector]
    public float step_Distance;
    void Start()
    {
        FootStepSound  = GetComponent<AudioSource>();
        character_controller = GetComponentInParent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckToPlayFootStepSound();
    }


    void CheckToPlayFootStepSound()
    {
        if(!character_controller.isGrounded)
        {
            return;
        }

        if(character_controller.velocity.sqrMagnitude > 0)
        {
            // then we are moving
            accumulated_Distance += Time.deltaTime;
            if(accumulated_Distance > step_Distance)
            {
                FootStepSound.volume = Random.Range(volume_Min, volume_Max);
                FootStepSound.clip = footstepclip[Random.Range(0, footstepclip.Length)];

                FootStepSound.Play();

                accumulated_Distance = 0f;
            }
       
        }
        else
        {
            accumulated_Distance = 0f;
        }
    }
}//class

















