using UnityEngine;
using UnityEngine.InputSystem;

public class DIG_Playermovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D Rb;
    public InputAction moveAction;
    public Vector2 moveInput;
    InputAction jumpaction;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    [Header("Ground check system")]
    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheckPosition;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpaction = InputSystem.actions.FindAction("Jump");

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        Collider2D hit = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundLayer);
        if (hit != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }


    void PlayerInput()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        Rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, Rb.linearVelocity.y);
        if (jumpaction.triggered)
        {
            Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, jumpForce);
        }

        if (jumpaction.WasPerformedThisFrame() && Rb.linearVelocity.y > 0)
        {
            Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, Rb.linearVelocity.y * jumpForce);
        }


        if (isGrounded && Rb.linearVelocity.y <= 0)
        {
            Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, 0);
        }
    }
}