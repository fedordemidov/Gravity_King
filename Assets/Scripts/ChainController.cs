using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainController : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] Rigidbody2D pendulum;
    private Material material;
    private Vector2 offset = Vector2.zero;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = material.GetTextureOffset("_MainTex");
    }


    void Update()
    {
        offset.x += Speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
        Speed = pendulum.angularVelocity / 20;
    }
}
