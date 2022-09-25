using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Training : MonoBehaviour
{
    enum Direction
    {
        Up,
        Left,
        Doun,
        Right
    }
    [SerializeField] Direction direction;
    [SerializeField] float second;
    Image sprite;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite.enabled = false;
        animator.enabled = false;
    }

    void FixedUpdate()
    {
        second--;
        if (second < 0)
        {

        }
    }
}
