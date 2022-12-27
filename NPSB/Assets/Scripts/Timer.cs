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

    [SerializeField] private AudioSource timerSound;
    [SerializeField] private AudioSource loseSound;
    public static bool audioPlays = false;
    int prevPlayTime = 11;

    [SerializeField] private GameObject loseScreen;
    private static bool openedLossScreen = false;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Started scene, isPaused: " + Globals.isPaused + "  isPausedExit: " + Globals.isPausedExit);
        loseScreen.SetActive(false);
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
            if(currentTime <= 10)
            {
                if (!audioPlays && (int)currentTime < prevPlayTime-1)
                {
       
                    timerSound.Play();
                    prevPlayTime= (int) currentTime + 1;
                }
            }
            if(currentTime <= 0){
                timerText.text = "TIME'S UP";
                timerText.color = Color.red;
                if(!openedLossScreen)
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

    public void FreezeScene()
    {
        openedLossScreen = true;
        loseSound.Play();
        loseScreen.SetActive(true);
        // Debug.Log("Showed loss screen, isPaused: " + Globals.isPaused + "  isPausedExit: " + Globals.isPausedExit);

        Globals.isPaused = true;
        Globals.isPausedExit = true;
        Globals.freezeMovement = true;
        Globals.freezeDrunkenness = true;
        Globals.freezeInteractions = true;
        // Debug.Log("Set all to true, isPaused: " + Globals.isPaused + "  isPausedExit: " + Globals.isPausedExit);

        // Time.timeScale = 0;
    }
}
