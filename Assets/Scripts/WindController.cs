using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public GameObject tpc;
    public MeshRenderer MeshRenderer;
    Vector3 dir;

    void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    void Update()
    {
        
    }

    private void OnSwipe(Vector2 direction)
    {
        MeshRenderer.material.SetVector("Gravity", direction);

        if (Physics2D.gravity == new Vector2(0, 10))
        {
            tpc.transform.rotation = Quaternion.Euler(0, 0, 180);
        }            
        else if (Physics2D.gravity == new Vector2(0, -10))
        {
            tpc.transform.rotation =Quaternion.Euler(0, 0, 0);
        }            
        else if (Physics2D.gravity == new Vector2(10, 0))
        {
            tpc.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Physics2D.gravity == new Vector2(-10, 0))
        {
            tpc.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }
}
