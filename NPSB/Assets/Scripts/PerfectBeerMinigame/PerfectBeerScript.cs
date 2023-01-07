using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PerfectBeerScript : MonoBehaviour
{
    public Slider slider;
    public Slider beerSlider;
    public RawImage beer;
    public TextMeshProUGUI instructionText;

    private float speed = 1.0f;
    private float maxSpeed = 2.0f;
    private bool leftToRight = true;
    private bool spacePressed = false;
    private bool stopGame = false;
    private float degree;
    private float topValue = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        slider.maxValue = 100;
        beerSlider.value = 0;
        beerSlider.maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !spacePressed)
        {
            spacePressed = true;
            instructionText.text = "";
            RotateBeer(slider.value);
        }

        if (!spacePressed)
        {
            IncreaseSpeed(slider.value);
            MoveHandle();
        }

        if(spacePressed && beerSlider.value < topValue && !stopGame)
        {
            PourBeer();
            CalculateScore();
            stopGame = true;
        }
    }

    public void IncreaseSpeed(float value)
    {
        if (value == 0 || value == 100)
        {
            leftToRight = !leftToRight;
            if (speed < maxSpeed)
            {
                speed += 0.1f;
            }
        }
    }

    public void MoveHandle()
    {
        if (leftToRight)
        {
            slider.value = slider.value + speed;
        }
        else
        {
            slider.value = slider.value - speed;
        }
    }

    public void RotateBeer(float sliderValue)
    {
        float degree = 90.0f * sliderValue / slider.maxValue;
        beer.transform.Rotate(0.0f, 0.0f, degree, Space.Self);
    }

    public void PourBeer()
    {
        beerSlider.value += 1.0f;
    }

    public void CalculateScore()
    {
        float sliderValue = slider.value;
        if (sliderValue < 20.0f || sliderValue > 80)
        {
            Globals.drunkenness -= 10;
        }
        else if (sliderValue < 40.0f || sliderValue > 60)
        {
            Globals.drunkenness += 5;
        }
        else
        {
            Globals.drunkenness += 10;
        }

        print(Globals.drunkenness);
    }
}
