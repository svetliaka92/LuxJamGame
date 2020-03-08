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
        // depending on the post type give the respective shard
        // metal post gives large shard
        // wooden post gives medium shard
        // decayed post gives small shard
        // decayed post also loses it's power if drained into a shard
        print("Post");
        onInteract?.Invoke();
    }

    public void StopInteract()
    {
        
    }
}
