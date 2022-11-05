using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIcon : MonoBehaviour
{
    [HideInInspector] public Image image;
    [HideInInspector] public RectTransform transform1;
    public int ActiveLevel, number;
    private float horizontalPosition;
    private float iconPosition;

    void OnEnable()
    {
        transform1 = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        SwipeDetection.SwipeEvent += OnSwipe;
        //isOpen();
    }

    void OnDisable()
    {
        SwipeDetection.SwipeEvent -= OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
        //transform1.localPosition += new Vector3(direction.x * 100, 0, 0);
        //isOpen();
    }

    void Update()
    {
        iconPosition = Mathf.Lerp(iconPosition, ((ActiveLevel + number) * 250), Time.deltaTime*10);
        transform1.localPosition = new Vector3(iconPosition, 0, 0);

        horizontalPosition = transform1.localPosition.x;

        if (horizontalPosition < 0)
            horizontalPosition *= -1;
            
        image.color = new Color(1, 1, 1, 1 - horizontalPosition / 800);
        transform1.localScale = new Vector3(1 - horizontalPosition / 1400, 1 - horizontalPosition / 1400, 1 - horizontalPosition / 1400);
    }

    public void isOpen()
    {
        if (-number < PlayerPrefs.GetInt("OpenLevels"))
        {
            gameObject.SetActive(false);
        }
    }
}
