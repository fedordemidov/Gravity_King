using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float Speed;
    public float horizontalInput;
    public LayerMask Wals;
    public bool _isGrounded;
    Rigidbody2D _rb;
    Animator _animator;
    Vector2 movement;
    BoxCollider2D box;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    void FixedUpdate()
    {
        Animator();

        RaycastHit2D raycastRight = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, new Vector2(1, 0), 0.1f, Wals);
        RaycastHit2D raycastLeft = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, new Vector2(-1, 0), 0.1f, Wals);

        if (raycastRight.collider != null && raycastRight.distance <= 0.2f)
        {
            horizontalInput = -1;
        }
        if (raycastLeft.collider != null && raycastLeft.distance <= 0.2f)
        {
            horizontalInput = 1;
        }

        if (_isGrounded)
        {
            movement = new Vector2(horizontalInput, _rb.velocity.y);
            _rb.velocity = (movement * Speed);
        }

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnSwipe(Vector2 direction)
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _animator.SetTrigger("Attack");
        }
        IsGroundedUpate(collision, true);
        Landing();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision2D collision, bool value)
    {
        //if (collision.gameObject.layer == Wals)
        {
            _isGrounded = value;
        }
    }

    void Landing()
    {
        if (Physics2D.gravity == new Vector2(0, 10))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }            
        else if (Physics2D.gravity == new Vector2(0, -10))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }            
        else if (Physics2D.gravity == new Vector2(10, 0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Physics2D.gravity == new Vector2(-10, 0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }

    void Animator()
    {
        if (horizontalInput == 0)
            _animator.SetBool("Run", false);
        else
            _animator.SetBool("Run", true);
    }

    void Death()
    {
        Speed = 0;
        _animator.SetTrigger("Death");
    }
}
