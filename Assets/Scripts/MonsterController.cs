using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [Header("Image")]
    private SpriteRenderer _sprite;
    private Animator _animator;

    [Header("Physics")]
    [SerializeField] private float Speed;      // Скорость скелета
    [SerializeField] private float Fall;       // Скорость падения
    private Rigidbody2D _rb;
    private bool isGrounded;  // На земле ли
    private Vector2 movement; // движение
    private Dir horizontal;   // Направление
    enum Dir
    {
        Centr = 0,
        Left = -1,
        Right = 1
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        horizontal = Dir.Right;

        _animator = transform.GetChild(0).GetComponent<Animator>();
        _sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();

        Direction.OnChange += ChangeGravity;
    }

    private void ChangeGravity()
    {
        Landing();
    }

    private void OnDisable()
    {
        Direction.OnChange -= ChangeGravity;
    }

    //(int)horizontal * Speed // передвижение
    void FixedUpdate()
    {
        Animator();
        ChangeMoving();
    }

    private void ChangeMoving()
    {
        if (!isGrounded)
        {
            _rb.velocity = Direction.vector2 * Fall;

        }
        else
        {
            if (Direction.vector2.x == 0 && _rb.velocity.x > -0.5f && _rb.velocity.x < 0.5f) // по горизонтали
            {
                if (Direction.vector2.y == -1)
                {
                    if (horizontal == Dir.Right)
                    {
                        _sprite.flipX = true;
                        _rb.velocity = Vector2.left * Speed;
                        horizontal = Dir.Left;
                    }
                    else
                    {
                        _sprite.flipX = false;
                        _rb.velocity = Vector2.right * Speed;
                        horizontal = Dir.Right;
                    }
                }
                else
                {
                    if (horizontal == Dir.Right)
                    {
                        _sprite.flipX = false;
                        _rb.velocity = Vector2.left * Speed;
                        horizontal = Dir.Left;
                    }
                    else
                    {
                        _sprite.flipX = true;
                        _rb.velocity = Vector2.right * Speed;
                        horizontal = Dir.Right;
                    }
                }
            }
            else if (Direction.vector2.y == 0 && _rb.velocity.y > -0.5f && _rb.velocity.y < 0.5f) // по вертикали
            {
                if (Direction.vector2.x == -1)
                {
                    if (horizontal == Dir.Right)
                    {
                        _sprite.flipX = false;
                        _rb.velocity = Vector2.down * Speed;
                        horizontal = Dir.Left;
                    }
                    else
                    {
                        _sprite.flipX = true;
                        _rb.velocity = Vector2.up * Speed;
                        horizontal = Dir.Right;
                    }
                }
                else
                {
                    if (horizontal == Dir.Right)
                    {
                        _sprite.flipX = true;
                        _rb.velocity = Vector2.down * Speed;
                        horizontal = Dir.Left;
                    }
                    else
                    {
                        _sprite.flipX = false;
                        _rb.velocity = Vector2.up * Speed;
                        horizontal = Dir.Right;
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _animator.SetTrigger("Attack");
        }
        IsGroundedUpate(collision, true);  
    }

    void OnCollisionExit2D(Collision2D collision) 
    {
        IsGroundedUpate(collision, false); 
    }

    private void IsGroundedUpate(Collision2D collision, bool value) { isGrounded = value; }


    void Landing()
    {
        transform.rotation = Quaternion.Euler(0, 0, Direction.angle);
    }

    void Animator()
    {
        _animator.SetBool("Run", (horizontal == 0 ? false : true ));
    }

    void Death()
    {
        Speed = 0;
        _animator.SetTrigger("Death");
    }
}