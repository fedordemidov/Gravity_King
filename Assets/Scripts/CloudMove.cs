using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float Speed;
    private Vector2 offset = Vector2.zero;
    private Vector3 moveVector;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = material.GetTextureOffset("_MainTex");

        var height = Camera.main.orthographicSize * 2f;
        var width = height * Screen.width / Screen.height;

        transform.localScale = new Vector3 (width, height, 0);
    }

    void Update()
    {
        offset.x += Speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
        //transform.position += moveVector * Time.deltaTime;
        
    }
}