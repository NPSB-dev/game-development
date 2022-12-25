using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackflipTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private AudioSource interactSuccessAudio;
    [SerializeField] private AudioSource interactFailAudio;

    public string InteractionPrompt => _prompt;

    public void Update()
    {
        if (Globals.drunkenness >= 100)
        {
            _prompt = "Do a backflip!";
        }
        else
        {
            _prompt = "Get 100% drunk before doing a backflip";
        }
    }


    public bool Interact(Interactor interactor)
    {
        if (Globals.drunkenness >= 100)
        {
            interactSuccessAudio.Play();
            Debug.Log("Start backflip");
            return true;
        }
        else
        {
            interactFailAudio.Play();
            Debug.Log("Not drunk enough to backflip");
            return false;
        }
    }
}
