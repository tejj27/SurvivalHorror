using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController Controller;

    public float Gravity = -9.81f;
    public float speed = 12f; 

    public Transform GroundCheck;
    public float GorundDistance;
    public LayerMask groundMask;

    Vector3 Velocity;

    bool IsGrounded;

    // Update is called once per frame
    void Update()
    {

        IsGrounded = Physics.CheckSphere(GroundCheck.position, GorundDistance, groundMask);

        if(IsGrounded && Velocity.y  < 0)
        {
            Velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Controller.Move(move * speed * Time.deltaTime);

        Velocity.y += Gravity * Time.deltaTime;
        
        Controller.Move(Velocity * Time.deltaTime);

    }
}
