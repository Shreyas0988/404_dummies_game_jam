using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot; 
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        onFoot.jump.performed += ctx => motor.jump();
        onFoot.crouch.performed += ctx => motor.crouch();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Tells player to move using the value from the movement action.
        motor.ProcessMove(onFoot.movement.ReadValue<Vector2>());
    }
    void LateUpdate()
    {
    
        look.ProcessLook(onFoot.look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
