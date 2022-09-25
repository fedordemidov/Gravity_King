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
    Animator animator;
    IEnumerator coroutine;

    void OnEnable()
    {
        animator = GetComponent<Animator>();
        coroutine = Timer();
        StartCoroutine(coroutine);
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    void OnDisable()
    {
        SwipeDetection.SwipeEvent -= OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
        gameObject.SetActive(false);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(second);
        switch (direction)
        {
            case Direction.Up:
                animator.SetTrigger("Up");
                break;
            case Direction.Left:
                animator.SetTrigger("Left");
                break;
            case Direction.Doun:
                animator.SetTrigger("Doun");
                break;
            case Direction.Right:
                animator.SetTrigger("Right");
                break;
        }
    }
}
