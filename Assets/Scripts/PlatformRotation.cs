using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    [SerializeField] Rigidbody2D pendulum;
    [SerializeField] float speed = 1;
    [SerializeField] Type type;

    enum Type
    {
        Platform,
        circle
    }

    void Update()
    {
        if (type == Type.circle)
        {
            transform.Rotate(0, 0, pendulum.angularVelocity * speed);
        }
        else
        {
            transform.rotation = pendulum.transform.rotation;
        }
    }
}
