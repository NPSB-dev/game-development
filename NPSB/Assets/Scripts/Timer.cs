using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    float minutes;
    float seconds;

    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown = true;
    public bool infinite = false;

    public bool started = false;

    // Start is called before the first frame update
    void Start()
    {

        if (Globals.DifficultyLevel == "easy"){
            currentTime = 600;
            minutes = 10;
            timerText.text = minutes.ToString("00") + ":" + "00";
        }
        if (Globals.DifficultyLevel == "normal"){
            currentTime = 300;
            minutes = 5;
            timerText.text = minutes.ToString("00") + ":" + "00";
        }
        if (Globals.DifficultyLevel == "hard"){
            currentTime = 180;
            minutes = 3;
            timerText.text = minutes.ToString("00") + ":" + "00";
        }
        if (Globals.DifficultyLevel == "endless"){
            infinite = true;
            timerText.text = "∞ : ∞";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.isPaused)
            return;
        if(!started){
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                started = true;
        }

        if(!infinite && started)
        {
            if(currentTime <= 0){
                timerText.text = "TIME'S UP";
                timerText.color = Color.red;
                FreezeScene();
            }
            else
            {
                currentTime = countDown ? currentTime - Time.deltaTime : currentTime + Time.deltaTime;        

                minutes = (int) currentTime / 60;
                seconds = (int) currentTime % 60;
                timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00"); 
            }
        }
    }

    public void FreezeScene(){
        Time.timeScale = 0;
        // ADD here after-game screen
    }
}
