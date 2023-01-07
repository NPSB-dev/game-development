using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PerfectBeerScript : MonoBehaviour
{
    public Slider slider;
    public RawImage beer;

    private float speed = 1.0f;
    private float maxSpeed = 2.0f;
    private bool leftToRight = true;
    private bool spacePressed = false;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        slider.maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !spacePressed)
        {
            RotateBeer(slider.value);
            spacePressed = true;
        }

        if (!spacePressed)
        {
            IncreaseSpeed(slider.value);
            MoveHandle();
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
}
