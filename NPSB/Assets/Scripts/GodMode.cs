using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{

    void Update()
    {
        if(Input.GetButtonDown("GodMode"))
            Globals.drunkenness = 100;
    }
}
