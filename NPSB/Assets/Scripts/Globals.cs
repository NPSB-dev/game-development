using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static Globals Instance { get; private set; }

    public static string DifficultyLevel;
    public static int drunkenness = 0;
    public static int nextTimeDecayDrunkenness = 10;
    public static float minutesToPlay = 0;
    public static float secondsToPlay = 0;
    public static Vector3 playerCoords = Vector3.zero; // spawn player to the correct position after a minigame is ended

    public static int isSucceedingBackflip = 0;

    //Pause settings:
    public static bool isPaused = false;
    public static bool isPausedExit = false;
    public static bool freezeMovement = false;
    public static bool freezeDrunkenness = false;
    public static bool freezeInteractions = false;

    public static int highscore = PlayerPrefs.GetInt("Highscore", 0);

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
    }
}
