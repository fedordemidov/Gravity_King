using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Direction
{
    public static Vector2 vector2;
    public static float angle;

    public delegate void DirectionHandler();
    public static event DirectionHandler OnChange;

    public static void Change(Vector2 vector)
    {
        vector2 = vector;
        angle = (vector == Vector2.up) ? 180f : (vector == Vector2.down) ? 0f : (vector == Vector2.left) ? 270f : 90f;
        OnChange?.Invoke();
    }
}