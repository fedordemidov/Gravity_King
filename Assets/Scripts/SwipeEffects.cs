using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeEffects : MonoBehaviour
{
    Vector3 dir;
    Image sprite;
    Animator animator;
    RectTransform rectTransform;

    void OnEnable()
    {
        SwipeDetection.SwipeEvent += OnSwipe;
        sprite = GetComponent<Image>();
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();
        ArrowOff();
    }

    void OnDisable()
    {
        SwipeDetection.SwipeEvent -= OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
        dir = direction == Vector2.up ? Vector3.forward : direction == Vector2.down ? Vector3.back : (Vector3)direction;
        dir.y = dir.z;
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

    void Landing()
    {
        Debug.Log(dir);
        if (dir == new Vector3(0, 1, 1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            Debug.Log(dir);
        }            
        else if (dir == new Vector3(0, -1, -1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Debug.Log(dir);
        }            
        else if (dir == new Vector3(1, 0, 0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            Debug.Log(dir);
        }
        else if (dir == new Vector3(-1, 0, 0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
            Debug.Log(dir);
        }
    }
}