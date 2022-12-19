using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrunkennessBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public TextMeshProUGUI drunkennessText;

    void Start()
    {
        drunkennessText.text = "0/100";
    }

    void Update()
    {
        drunkennessText.text = slider.value.ToString() + "/100";
    }
    

    public void SetMaxDrunkenness(int drunkenness)
    {
        slider.maxValue = drunkenness;
        slider.value = 0;
        fill.color = gradient.Evaluate(0f);
    }

    public int GetMaxDrunkenness()
    {
        return (int)slider.maxValue;
    }

    public int GetDrunkenness()
    {
        return Globals.drunkenness;
    }
    
    public void SetDrunkenness(int drunkenness)
    {
        Globals.drunkenness = drunkenness;
        slider.value = drunkenness;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
