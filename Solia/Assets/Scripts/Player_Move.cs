using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Move : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 moveDirection; //movement direction asked by the player for the next frame
    private Vector2 actualMoveDirection = Vector2.zero; //real value with acceleration, tend to move direction
    
    [Tooltip("Controller associated with player character")]
    [SerializeField] private CharacterController characterController;

    [Tooltip("Character's Move Speed")] 
    [SerializeField] private float characterMoveSpeed = 7;

    [Tooltip("Acceleration's percentage per frame")] 
    [SerializeField] private float accelerationPercent = 0.17f;    
    
    
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Movement(InputAction.CallbackContext callbackContext)
    {
        Debug.Log(callbackContext.phase);
        if (callbackContext.performed)
        {
            moveDirection = callbackContext.ReadValue<Vector2>(); //calculation
        }
        else if (callbackContext.canceled)
        {
            moveDirection = Vector2.zero; //Stop movement
        }
    }
    
    public void FixedUpdate()
    {
        actualMoveDirection += accelerationPercent * (moveDirection - actualMoveDirection);
        characterController.Move(actualMoveDirection * characterMoveSpeed * Time.deltaTime); //do movement
    }
}