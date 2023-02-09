using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private LayerMask wallLayer;
    private float movementInputDirection;

    private bool isFacingRight = true;

    private bool isWalking;
    private bool isGrounded;
    private bool isWall;
    private bool isDashing;
    [SerializeField]
    private float dashTime;
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float distanceBetweenImages;
    [SerializeField]
    private float dashCooldown;
    private float dashTimeLeft;
    private float lastImageXpos;
    private float lastDash = -100f;
    private bool canMove = true;
    private bool canFlip = true;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update() 
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        checkDash();
    }
    private void FixedUpdate() 
    {
        ApplyMovement();
        checkSurroundings();
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            AttemptToDash();
        }
    }

    private void AttemptToDash()
    {
        if (Time.time - lastDash < dashCooldown)
        {
            return;
        }
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;
        PlayerAfterImagePool.Instance.GetFromPool();
        lastImageXpos = transform.position.x;
    }

    private void checkDash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0 && !isWall)
            {
                canMove = false;
                DisableFlip();
                body.velocity = new Vector2(dashSpeed * transform.localScale.x, body.velocity.y);
                dashTimeLeft -= Time.deltaTime;

                if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                {
                    PlayerAfterImagePool.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }
            }
            if (dashTimeLeft <= 0 || isWall)
            {
                isDashing = false;
                canMove = true;
                EnableFlip();
            }
        }
    }

    private void ApplyMovement()
    {
        if (canMove && !isWall)
        {
            body.velocity = new Vector2(movementInputDirection * speed, body.velocity.y);
        }
        
    }

    private void CheckMovementDirection()
    {
        if ((isFacingRight && movementInputDirection < 0 || !isFacingRight && movementInputDirection > 0) && canFlip)
        {
            Flip();
        }
        if (body.velocity.x != 0)
        {
            isWalking = true;
        } else {
            isWalking = false;
        }
        isFacingRight = !isFacingRight;
    }
    
    private void Flip()
    {
        if (movementInputDirection > 0)
        {
            transform.localScale = Vector3.one;
        }
        if (movementInputDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", body.velocity.y);
    }

    private void checkSurroundings()
    {
        RaycastHit2D hitGround = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, groundLayer);
        isGrounded = hitGround.collider != null;

        RaycastHit2D hitWall = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.01f, wallLayer);
        isWall = hitWall.collider != null;
    }


    private void DisableFlip()
    {
        canFlip = false;
    }

    private void EnableFlip()
    {
        canFlip = true;
    }
    
}
