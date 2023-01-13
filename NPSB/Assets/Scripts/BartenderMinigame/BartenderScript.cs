using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BartenderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Globals.isPaused = false;
        Globals.isPausedExit = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneTransition()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
