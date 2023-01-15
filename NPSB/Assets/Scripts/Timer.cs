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

    public float currentTime;
    public bool countDown = true;

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
        openedLossScreen = false;
        // Debug.Log("Started scene, isPaused: " + Globals.isPaused + "  isPausedExit: " + Globals.isPausedExit);
        loseScreen.SetActive(false);
        minutes = Globals.minutesToPlay;
        seconds = Globals.secondsToPlay;
        currentTime = minutes * 60 + seconds;
        if (minutes >= 0)
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        else
            timerText.text = "∞ : ∞";
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

        if(minutes >= 0 && started)
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
                Globals.minutesToPlay = 0;
                Globals.secondsToPlay = 0;
                if (!openedLossScreen)
                    FreezeScene();
            }
            else
            {
                currentTime = countDown ? currentTime - Time.deltaTime : currentTime + Time.deltaTime;        

                minutes = (int) currentTime / 60;
                seconds = (int) currentTime % 60;
                timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

                Globals.minutesToPlay = minutes;
                Globals.secondsToPlay = seconds;
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
