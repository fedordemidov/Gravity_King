using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityController : MonoBehaviour
{
    public Vector2 StartGravity;

    void Start()
    {
        Physics2D.gravity = StartGravity;
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    private void OnSwipe(Vector2 dir)
    {
        Direction.Change(dir);
        Physics2D.gravity = Direction.vector2 * 10;
    }
}