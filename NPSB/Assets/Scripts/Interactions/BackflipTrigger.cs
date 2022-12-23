using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackflipTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public void Update()
    {
        if (Globals.drunkenness >= 100)
        {
            _prompt = "Do a backflip!";
        }
        else
        {
            _prompt = "Get 100% drunk and do a backflip";
        }
    }


    public bool Interact(Interactor interactor)
    {
        if (Globals.drunkenness >= 100)
        {
            Debug.Log("Start backflip");
            return true;
        }
        else
        {
            Debug.Log("Not drunk enough to backflip");
            return false;
        }
    }
}
