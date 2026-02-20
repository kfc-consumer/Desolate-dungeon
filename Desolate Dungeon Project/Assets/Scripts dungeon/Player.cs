using System;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{


    Rigidbody2D playerRb;

    InputAction moveAction;
    InputAction jumpAction;
  
    Vector2 moveInput;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    
    



    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        

    }


    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (jumpAction.WasPerformedThisFrame())
        {
            playerRb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        

    }

   

    void FixedUpdate()
    {
        playerRb.linearVelocityX = moveInput.x * moveSpeed;
    }

    

}
