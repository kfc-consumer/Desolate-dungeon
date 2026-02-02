using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class DIG_Playermovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D Rb;
    public InputAction moveAction;
    public Vector2 moveInput;
    InputAction jumpaction;
    private TrailRenderer trailRenderer;
    private bool dashInput;

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


    [Header("Dash Related")]
    [SerializeField] private float dashingVelocity;
    [SerializeField] private float dashingTime;
    private Vector2 dashDirection;
    private bool isDashing;
    private bool canDash = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpaction = InputSystem.actions.FindAction("Jump");
        playerStatusManager = FindAnyObjectByType<PS_Manager>();
        trailRenderer = GetComponent<TrailRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        dashInput = Input.GetButtonDown("Dash");
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
        if (dashInput && canDash)
        {
            
            isDashing = true;
            canDash = false;
            trailRenderer.emitting = true;
            dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            if (dashDirection == Vector2.zero)
            {
                dashDirection = new Vector2(transform.localScale.x, 0);
            }
            StartCoroutine(StopDashing());
        }

        if (isDashing)
        {
            Rb.linearVelocity = dashDirection.normalized * dashingVelocity;
            return;
        }

        if (isGrounded)
        {
            canDash = true;
        }

    }

    void WhenDMG()
    {
        playerStatusManager.TakeDamage(1);
    }


    IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        isDashing = false;
        
    }
}