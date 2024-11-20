using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -15.8f;
    public float jumpHeight = 1f;
    public bool lerpcrouch = false;
    public bool crouching = false;
    public float crouchTimer = 0f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (lerpcrouch){
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            speed = 1f;
            if (crouching){
                controller.height = Mathf.Lerp(controller.height, 1, p);
                speed = 1f;
            }
            else{
                controller.height = Mathf.Lerp(controller.height, 2, p);
                speed = 5f;
            }

            if (p>1){
                lerpcrouch = false;
                crouchTimer = 0f;
            }

        }
        isGrounded = controller.isGrounded;

    }

    
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity* Time.deltaTime);
        
    }
    public void jump(){
        if(isGrounded){
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
    public void crouch(){
        crouching = !crouching;
        crouchTimer = 0;
        lerpcrouch = true;
    }
}
