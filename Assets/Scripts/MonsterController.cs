using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] float Speed;
    public float horizontalInput;
    public Transform Tagret;
    [SerializeField] LayerMask Wals;
    bool _isGrounded;
    Rigidbody2D _rb;
    Animator _animator;
    Vector2 movement;
    BoxCollider2D box;
    SpriteRenderer _sprite;
    Vector2 _direction;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    void FixedUpdate()
    {
        Animator();
        
        Quaternion rotation = Quaternion.LookRotation(_direction);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5 * Time.deltaTime);

        if (_isGrounded)
        {
            movement = new Vector2(Tagret.position.x - transform.position.x, Tagret.position.y- transform.position.y);
            _rb.velocity = (movement * horizontalInput * Speed);
        }

        if (horizontalInput > 0.01f)
            _sprite.flipX = false;
            //transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalInput < -0.01f)
            _sprite.flipX = true;
            //transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnSwipe(Vector2 direction)
    {
        _direction = direction;
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
        _isGrounded = value;
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