using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPongTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private AudioSource interactSuccessAudio;
    [SerializeField] private AudioSource interactFailAudio;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        interactSuccessAudio.Play();
        Debug.Log("Start beer pong");
        var levelChanger = GameObject.FindObjectOfType(typeof(LevelChanger)) as LevelChanger;

        var player = GameObject.FindGameObjectWithTag("Remy");

        Globals.playerCoords = player.transform.position;

        levelChanger.FadeToLevel(6);
        return true;
    }
}
