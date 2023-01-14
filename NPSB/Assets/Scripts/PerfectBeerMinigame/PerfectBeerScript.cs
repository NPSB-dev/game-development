using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PerfectBeerScript : MonoBehaviour
{
    public Slider slider;
    public Slider beerSlider;
    public RawImage beer;
    public TextMeshProUGUI instructionText;
    public GameObject resultScreen;
    public TextMeshProUGUI resultText;
    public DrunkennessBar drunkennessBar;

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
        Globals.isPaused = false;
        Globals.isPausedExit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !spacePressed)
        {
            spacePressed = true;
            instructionText.text = "";
            RotateBeer(slider.value);
            CalculateScore();
        }

        if (!spacePressed)
        {
            IncreaseSpeed(slider.value);
            MoveHandle();
        }

        if(spacePressed && beerSlider.value < topValue)
        {
            PourBeer();
        }

        if (stopGame)
        {   
            SceneTransition();
        }

        if (spacePressed && beerSlider.value == topValue && !stopGame)
        {
            PromptFinalScreen();
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
            if (Globals.drunkenness >= 10)
                Globals.drunkenness += 100;
            else
                Globals.drunkenness = 0;
        }
        else if (sliderValue < 40.0f || sliderValue > 60)
        {
            if (Globals.drunkenness <= 95)
                Globals.drunkenness += 100;
            else
                Globals.drunkenness = 100;
        }
        else
        {
            if (Globals.drunkenness <= 90)
                Globals.drunkenness += 100;
            else
                Globals.drunkenness = 100;
        }
        print(Globals.drunkenness);
    }

    public void PromptFinalScreen()
    {
        resultScreen.SetActive(true);
        SetResultText();
    }

    public void SceneTransition()
    {
        var levelChanger = GameObject.FindObjectOfType(typeof(LevelChanger)) as LevelChanger;

        levelChanger.FadeToLevel(1);
    }

    public void SetResultText()
    {
        float value = slider.value;
        if (value < 20 || value > 80)
        {
            resultText.text = "Auch! \n\n -10 points";
        }
        else if (value < 40 || value > 60)
        {
            resultText.text = "Ok! \n\n +5 points";
        }
        else
        {
            resultText.text = "Yum! \n\n +10 points";
        }
    }
}
