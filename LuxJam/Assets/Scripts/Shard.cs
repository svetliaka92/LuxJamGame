using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour, IInteractable
{
    [SerializeField] private ShardType type;

    public void Hover()
    {
        // show item tag
    }

    public void Interact()
    {
        if (Inventory.Instance)
            Inventory.Instance.OnItemPicked(type);

        gameObject.SetActive(false);
    }

    public void StopInteract()
    {
        
    }
}
