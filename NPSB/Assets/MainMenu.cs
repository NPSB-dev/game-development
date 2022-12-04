using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SetDifficulty(int difficultyLevel)
    {
        NPSB_singleton.DifficultyLevel = difficultyLevel;

        Play();
    }

    public void Play()
    {
        //SceneManager.LoadScene("SceneNAME");
        // 0 is the menu scene, we're adding 1 to the current scene so we get the next one
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
