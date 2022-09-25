using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeEffects : MonoBehaviour
{
    Image sprite;
    Animator animator;

    void OnEnable()
    {
        SwipeDetection.SwipeEvent += OnSwipe;
        sprite = GetComponent<Image>();
        animator = GetComponent<Animator>();
        ArrowOff();
    }

    void OnDisable()
    {
        SwipeDetection.SwipeEvent -= OnSwipe;
    }

    private void OnSwipe(Vector2 dir)
    {
        if (this != null)
        {
            Landing(dir);
            ArrowOn();
        }        
    }

    public void ArrowOn()
    {
        sprite.enabled = true;
        animator.enabled = true;
    }

    public void ArrowOff()
    {
        sprite.enabled = false;
        animator.enabled = false;
    }

    private void Landing(Vector2 dir)
    {
        float angleZ = (dir == Vector2.up) ? 180f : (dir == Vector2.down) ? 0f : (dir == Vector2.left) ? 270f : 90f;
        transform.rotation = Quaternion.Euler(0, 0, angleZ);
    }
}