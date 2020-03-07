using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastHandler : MonoBehaviour
{
    [SerializeField] private CameraRaycaster _cameraRaycaster;

    private IInteractable _interactable;

    private void Update()
    {
        HandleHover();
        HandleInteract();
    }

    private void HandleHover()
    {
        if (_cameraRaycaster.Hit != null)
        {
            IInteractable interactable = _cameraRaycaster.Hit.Value.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Hover();
            }
        }
    }

    private void HandleInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_cameraRaycaster.Hit != null)
            {
                IInteractable interactable = _cameraRaycaster.Hit.Value.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    _interactable = interactable;
                    _interactable.Interact();
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            if (_interactable != null)
                _interactable.StopInteract();
        }
    }
}
