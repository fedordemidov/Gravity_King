using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private BoxCollider2D box;
    private SpriteRenderer sprite;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Open()
    {
        box.enabled = false;
        sprite.enabled = false;
    }

    public void Close()
    {
        box.enabled = true;
        sprite.enabled = true;
    }
}
