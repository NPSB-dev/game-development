using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BeerPongScript : MonoBehaviour
{
    public Ball ball;
    public GameObject cup;
    public GameObject resultScreen;
    public TextMeshProUGUI resultText;

    private bool stopGame = false;

    // Start is called before the first frame update
    void Start()
    {

        Globals.isPaused = false;
        Globals.isPausedExit = false;
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsBallInsideCup() && !stopGame)
        {
            Win();
        }
        if (!stopGame && BallOutsideOfCanvas())
        {
            Lose();
        }
    }

    public void Win()
    {
        stopGame = true;
        PromptFinalScreen();
        SceneTransition();
    }

    public void Lose()
    {
        stopGame = true;
        PromptFinalScreen();
        SceneTransition();
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        Lose();
    }

    public Vector3 GetCupCoord()
    {
        return cup.transform.position;
    }

    public bool IsBallInsideCup()
    {
        var cupCoordinates = GetCupCoord();
        var ballCoordinates = ball.pos;

        if (Math.Abs(ballCoordinates.x - cupCoordinates.x) < 4 && (Math.Abs(cupCoordinates.y - ballCoordinates.y)) < 100)
        {
            return true;
        }
        return false;
    }
    
    public bool BallOutsideOfCanvas()
    {
        var ballCoordinates = ball.pos;

        if (ballCoordinates.x <= 0 || ballCoordinates.x >= 1920)
        {
            return true;
        }
        return false;
    }

    public void SceneTransition()
    {
        var levelChanger = GameObject.FindObjectOfType(typeof(LevelChanger)) as LevelChanger;

        levelChanger.FadeToLevel(1);
    }

    public void PromptFinalScreen()
    {
        resultScreen.SetActive(true);
        SetResultText();
    }

    public void SetResultText()
    {
        if (!IsBallInsideCup())
        {
            if (Globals.drunkenness >= 10)
                Globals.drunkenness -= 10;
            else
                Globals.drunkenness = 0;
            resultText.text = "Auch! \n\n -10 points";
        }
        else
        {
            if (Globals.drunkenness <= 90)
                Globals.drunkenness += 10;
            else
                Globals.drunkenness = 100; 
            resultText.text = "Wow! \n\n +10 points";
        }
    }
}
