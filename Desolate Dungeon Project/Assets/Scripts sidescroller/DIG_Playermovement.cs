using System.Runtime.CompilerServices;
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

    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;


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

        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

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
            Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, Rb.linearVelocity.y * 0.5f);
        }


        if (jumpaction.WasPerformedThisFrame() && isGrounded || jumpaction.WasPerformedThisFrame() && coyoteTimeCounter > 0)
        {
            coyoteTimeCounter = 0;
            Rb.linearVelocityY = 0;
            Rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


    }

    private void FixedUpdate()
    {
       if (!isGrounded && Rb.linearVelocityY > 0 && jumpaction.IsPressed()) 
            {
            Rb.AddForce(Vector2.down * 40);
        }

    }
}