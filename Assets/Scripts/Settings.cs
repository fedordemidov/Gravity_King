using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Slider SliderSize;
    [SerializeField] Slider SliderTransparency;

    [Space]
    [SerializeField] Image[] color;

    [Space]
    [SerializeField] RectTransform[] rectTransform;

    void Start()
    {
        SliderSize.value = PlayerPrefs.GetFloat("ButtonSize") + 0.5f;
        SliderTransparency.value = PlayerPrefs.GetFloat("ButtonTransparency") + 0.5f;
    }

    void Update()
    {
        
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("ButtonSize", SliderSize.value - 0.5f);
        PlayerPrefs.SetFloat("ButtonTransparency", SliderTransparency.value - 0.5f);
    }

    public void Apply()
    {
        for (int i=0; i < rectTransform.Length; i++)
        {
            rectTransform[i].localScale = new Vector3(1 + (SliderSize.value - 0.5f), 1 + (SliderSize.value - 0.5f), 1);
        }

        for (int i=0; i < color.Length; i++)
        {
            color[i].color = new Color(1, 1, 1, SliderTransparency.value);
        }
    }
}
