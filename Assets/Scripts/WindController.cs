using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public GameObject tpc;
    public MeshRenderer MeshRenderer;

    void OnEnable()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        Direction.OnChange += ChangeGravity;
    }

    void OnDisable()
    {
        Direction.OnChange -= ChangeGravity;
    }

    private void ChangeGravity()
    {
        MeshRenderer.material.SetVector("Gravity", Direction.vector2);
        tpc.transform.rotation = Quaternion.Euler(0, 0, Direction.angle);
    }
}
