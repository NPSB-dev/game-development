using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SetDifficulty(string difficultyLevel)
    {
        Globals.DifficultyLevel = difficultyLevel;
        if (Globals.DifficultyLevel == "easy")
        {
            Globals.minutesToPlay = 5;
        }
        if (Globals.DifficultyLevel == "normal")
        {
            Globals.minutesToPlay = 3;
        }
        if (Globals.DifficultyLevel == "hard")
        {
            Globals.minutesToPlay = 2;
        }
        if (Globals.DifficultyLevel == "endless")
        {
            Globals.minutesToPlay = -1;
        }

        Globals.isPaused = false;
        Globals.isPausedExit = false;
        Globals.freezeMovement = false;
        Globals.freezeDrunkenness = false;
        Globals.freezeInteractions = false;
        Globals.isSucceedingBackflip = 0;
        Globals.drunkenness = 0;
        Play();
    }

    public void Play()
    {
        //SceneManager.LoadScene("SceneNAME");
        // 0 is the menu scene, we're adding 1 to the current scene so we get the next one
        Globals.playerCoords = Vector3.zero;
        Globals.secondsToPlay = 0;

        var playGame = SceneManager.GetActiveScene().buildIndex + 1;

        var levelChanger = GameObject.FindObjectOfType(typeof(LevelChanger)) as LevelChanger;

        levelChanger.FadeToLevel(playGame);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
