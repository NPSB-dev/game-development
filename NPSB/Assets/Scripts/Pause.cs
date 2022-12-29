using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseOverlay;


    // Start is called before the first frame update
    void Start()
    {
        PauseOverlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!Globals.isPaused)
            {
                Globals.freezeMovement = true;
                Globals.freezeDrunkenness = true;
                Globals.freezeInteractions = true;
                Globals.isPaused = true;
                PauseOverlay.SetActive(true);
            }
            else
            {
                PauseOverlay.SetActive(false);
                if (!Globals.isPausedExit)
                {
                    Globals.freezeMovement = false;
                    Globals.freezeDrunkenness = false;
                    Globals.freezeInteractions = false;
                }
                Globals.isPaused = false;
            }
        }
    }
}
