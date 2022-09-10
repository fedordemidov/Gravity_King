using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed, JumpForce;
    public GameObject body;
    public LayerMask ground;
    public bool Grounded;
    public float ButtonInput;
    public float boost;
    public float ButtonSpeed;
    Rigidbody2D rb;
    Animator animator;
    bool isMove;
    BoxCollider2D boxCollider;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = body.GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = (Input.GetAxis("Horizontal") + ButtonInput);
        rb.velocity = new Vector2((horizontalInput) * Speed, rb.velocity.y);

        if (Input.GetKeyDown("space"))
            Jump();

        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        animator.SetBool("Run", horizontalInput > 0.1f || horizontalInput < -0.1f);
        animator.SetBool("Fall", !isGrounded());
        if (!isGrounded())
        {
            if (rb.velocity.y > 0.01f)
                animator.SetBool("Jump", true);
            else
                animator.SetBool("Jump", false);
        }
        else
            animator.SetBool("Jump", false);

        ButtonInputMove();
    }

    public void Jump()
    {
        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }        
    }

    public bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, ground);
        Grounded = raycastHit.collider != null;
        return raycastHit.collider != null;
    }

    public void HorizontalMove(int speed)
    {
        ButtonSpeed = speed;
        //ButtonInput = Mathf.Lerp(0, speed, Time.deltaTime*boost);
    }

    void ButtonInputMove()
    {
        ButtonInput = Mathf.Lerp(ButtonInput, ButtonSpeed, Time.deltaTime*boost);
    }
}