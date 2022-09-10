using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    Vector3 dir;
    public Vector2 StartGravity;

    void Start()
    {
        Physics2D.gravity = StartGravity;
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
        dir = direction == Vector2.up ? Vector3.forward : direction == Vector2.down ? Vector3.back : (Vector3)direction;
        dir.y = dir.z;
        Physics2D.gravity = dir * 10;
    }
}
