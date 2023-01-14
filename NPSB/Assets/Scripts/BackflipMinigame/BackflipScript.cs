using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BackflipScript : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI instructionText;
    [SerializeField] private GameObject winScreen;

    public GameObject loseScreen;
    public DrunkennessBar drunkennessBar;
    public static bool openedWinScreen = false;

    [SerializeField] private TextMeshProUGUI scoreToDisplay;
    [SerializeField] private TextMeshProUGUI highscoreDisplay;

    private float speed = 1.0f;
    private float maxSpeed = 2.0f;
    private bool leftToRight = true;
    private bool spacePressed = false;
    private bool stopGame = false;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        slider.maxValue = 100;
        Globals.isPaused = false;
        Globals.isPausedExit = false;
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !spacePressed)
        {
            spacePressed = true;
            instructionText.text = "";
            WinOrLose();
        }

        if (!spacePressed)
        {
            IncreaseSpeed(slider.value);
            MoveHandle();
        }

        if (stopGame)
        {
            PromptFinalScreen();
        }

        if (spacePressed && !stopGame)
        {
            StartCoroutine(WaitForAnimationToEnd());
        }
    }

    IEnumerator WaitForAnimationToEnd()
    {
        if (Globals.isSucceedingBackflip == 1)
        {
            yield return new WaitForSeconds(2.5f);
        }
        if (Globals.isSucceedingBackflip == 2)
        {
            yield return new WaitForSeconds(4.0f);
        }
        stopGame = true;
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

    public void WinOrLose()
    {
        float sliderValue = slider.value;
        if (sliderValue < 40 || sliderValue > 60)
        {
            Globals.isSucceedingBackflip = 1;
        }
        else
        {
            Globals.isSucceedingBackflip = 2;
        }
    }

    public void PromptFinalScreen()
    {
        if (slider.value < 40 || slider.value > 60)
        {
            loseScreen.SetActive(true);
        }
        else
        {
            WinGame();
        }

        Globals.isPaused = true;
        Globals.isPausedExit = true;
        Globals.freezeMovement = true;
        Globals.freezeDrunkenness = true;
        Globals.freezeInteractions = true;
    }

    public void WinGame()
    {
        openedWinScreen = true;
        winScreen.SetActive(true);
        int score = CalculateScore();
        scoreToDisplay.text = "Score: " + score;

        if (score > Globals.highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            Globals.highscore = score;
        }
        highscoreDisplay.text = "Highscore: " + Globals.highscore;

        Debug.Log("Did backflip");
    }

    public int CalculateScore()
    {
        // int score = 0;
        float multiplier = 0;
        // int totalSec;
        float timeLeft = Globals.minutesToPlay * 60 + Globals.secondsToPlay;

        if (Globals.DifficultyLevel == "easy")
        {
            multiplier = 1f;
            // totalSec = 600;
        }
        if (Globals.DifficultyLevel == "normal")
        {
            multiplier = 2f;
            // totalSec = 300;
        }
        if (Globals.DifficultyLevel == "hard")
        {
            multiplier = 3f;
            // totalSec = 180;
        }
        if (Globals.DifficultyLevel == "endless")
        {
            return 0;
        }

        return (int)(multiplier * timeLeft);

    }
}
