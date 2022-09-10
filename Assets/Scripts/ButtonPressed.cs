using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    public Sprite BaseSprite;
    public Sprite PressedSprite;
    public Gate gate;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gate.Close();
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D()
    {
        gate.Open();
        spriteRenderer.sprite = PressedSprite;
    }

    void OnTriggerExit2D()
    {
        gate.Close();
        spriteRenderer.sprite = BaseSprite;
    }
}
