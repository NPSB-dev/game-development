using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPSB_singleton : MonoBehaviour
{
    public static NPSB_singleton Instance { get; private set; }

    public static int DifficultyLevel; //0 - easy, 1 - normal, 2 - hard , 3 - endless

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
