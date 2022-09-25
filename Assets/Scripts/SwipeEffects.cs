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
        Direction.OnChange += OnChange;
        sprite = GetComponent<Image>();
        animator = GetComponent<Animator>();
        ArrowOff();
    }

    void OnDisable()
    {
        Direction.OnChange -= OnChange;
    }

    private void OnChange()
    {
        if (this != null)
        {
            Landing();
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

    private void Landing()
    {
        transform.rotation = Quaternion.Euler(0, 0, Direction.angle);
    }
}