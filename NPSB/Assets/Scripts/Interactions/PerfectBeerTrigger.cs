using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerfectBeerTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private AudioSource interactSuccessAudio;
    [SerializeField] private AudioSource interactFailAudio;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        interactSuccessAudio.Play();
        Debug.Log("Start perfect beer");

        var levelChanger = GameObject.FindObjectOfType(typeof(LevelChanger)) as LevelChanger;

        var player = GameObject.FindGameObjectWithTag("Remy");

        Globals.playerCoords = player.transform.position;

        levelChanger.FadeToLevel(2);
        return true;
    }
}
