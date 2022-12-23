using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactionableMask;

    private readonly Collider[] _colliders = new Collider[5];
    [SerializeField] private int _numFound;

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactionableMask);

        if(_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<IInteractable>();

            if(interactable != null && Input.GetButtonDown("Interact"))
            {
                interactable.Interact(this);
            }

        }
    }

}
