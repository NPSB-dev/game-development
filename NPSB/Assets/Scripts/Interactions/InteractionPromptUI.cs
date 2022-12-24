using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{
    [SerializeField] private GameObject InteractPrompt;
    [SerializeField] private TextMeshProUGUI _promptText;

    // Start is called before the first frame update
    void Start()
    {
        InteractPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsDisplayed = false;

    public void ShowInteract(string promptText)
    {
        _promptText.SetText("Press E to: " + promptText);
        InteractPrompt.SetActive(true);
        IsDisplayed = true;
    }

    public void HideInteract()
    {
        InteractPrompt.SetActive(false);
        IsDisplayed = false;
    }
}
