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

    [Header("Player Status")]

    [SerializeField] int PlayerHealthPoints;

    PS_Manager playerStatusManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpaction = InputSystem.actions.FindAction("Jump");
        playerStatusManager = FindAnyObjectByType<PS_Manager>();

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
        if (jumpaction.triggered && isGrounded)
        {
            Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, jumpForce);
        }


        if (jumpaction.WasPerformedThisFrame() && isGrounded || jumpaction.WasPerformedThisFrame() && coyoteTimeCounter > 0)
        {
            coyoteTimeCounter = 0;
            Rb.linearVelocityY = 0;
            Rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }



    }

    void WhenDMG()
    {
        playerStatusManager.TakeDamage(1);
    }
}