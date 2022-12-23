using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactionableMask;
    [SerializeField] private InteractionPromptUI interactionPromptUI;


    private readonly Collider[] _colliders = new Collider[5];
    [SerializeField] private int _numFound;

    public IInteractable interactable;

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactionableMask);

        if(_numFound > 0)
        {
            interactable = _colliders[0].GetComponent<IInteractable>();

            if(interactable != null)
            {
                if (!interactionPromptUI.IsDisplayed)
                {
                    interactionPromptUI.ShowInteract(interactable.InteractionPrompt);
                }

                if (Input.GetButtonDown("Interact"))
                {
                    interactable.Interact(this);
                }
            }

        }
        else
        {
            if(interactable != null) interactable = null;
            if (interactionPromptUI.IsDisplayed)
                interactionPromptUI.HideInteract();
        }
    }

}
