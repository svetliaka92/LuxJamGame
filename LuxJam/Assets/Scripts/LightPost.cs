using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPost : MonoBehaviour, IInteractable
{
    public PostType postType;

    public event Action onInteract;

    public void Hover()
    {
        
    }

    public void Interact()
    {
        onInteract?.Invoke();
    }

    public void StopInteract()
    {
        
    }
}
