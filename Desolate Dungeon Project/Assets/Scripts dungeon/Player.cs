using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{


    Rigidbody2D playerRb;

    InputAction moveAction;
    Vector2 moveInput;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
    }


    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        playerRb.linearVelocityX = moveInput.x;
    }

}
