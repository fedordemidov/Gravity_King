using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIcon : MonoBehaviour
{
    private Image image;
    [HideInInspector] public RectTransform transform1;
    [HideInInspector] public int ActiveLevel, i;
    private float horizontalPosition;
    private float iconPosition;

    void Start()
    {
        transform1 = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
        //transform1.localPosition += new Vector3(direction.x * 100, 0, 0);
    }

    void Update()
    {
        iconPosition = Mathf.Lerp(iconPosition, ((ActiveLevel + i) * 250), Time.deltaTime*10);
        transform1.localPosition = new Vector3(iconPosition, 0, 0);

        horizontalPosition = transform1.localPosition.x;

        if (horizontalPosition < 0)
            horizontalPosition *= -1;
            
        image.color = new Color(1, 1, 1, 1 - horizontalPosition / 800);
        transform1.localScale = new Vector3(1 - horizontalPosition / 1400, 1 - horizontalPosition / 1400, 1 - horizontalPosition / 1400);
    }
}
