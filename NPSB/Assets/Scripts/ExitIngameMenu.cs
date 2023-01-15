using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitIngameMenu : MonoBehaviour
{
    public GameObject exitMenu = null;


    // Start is called before the first frame update
    void Start()
    {
        if (exitMenu != null)
            exitMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(exitMenu == null) { return; }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Globals.isPausedExit)
            {
                ResumeGame();
            }
            else { PauseGame(); }
        }
    }

    public void ResumeGame()
    {
        if (!Globals.isPaused)
        {
            Globals.freezeMovement = false;
            Globals.freezeDrunkenness = false;
            Globals.freezeInteractions = false;
        }
        Globals.isPausedExit = false;
        exitMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {

        exitMenu.SetActive(true);
        Globals.freezeMovement = true;
        Globals.freezeDrunkenness = true;
        Globals.freezeInteractions = true;
        Globals.isPausedExit = true;
        Time.timeScale = 0f;
    }

    public void GoToMainMenu()
    {

        // Debug.Log("Into GoToMainMenu, isPaused: " + Globals.isPaused + "  isPausedExit: " + Globals.isPausedExit);
        Time.timeScale = 1f; 
        Globals.freezeMovement = false;
        Globals.freezeDrunkenness = false;
        Globals.freezeInteractions = false;
        Globals.isPausedExit = false;
        Globals.isPaused = false;

        Globals.drunkenness = 0;
        BackflipScript.openedWinScreen = false;
        // Debug.Log("End of GoToMainMenu, isPaused: " + Globals.isPaused + "  isPausedExit: " + Globals.isPausedExit);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
