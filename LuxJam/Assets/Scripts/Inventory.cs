using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory _instance;
    public static Inventory Instance => _instance;

    [SerializeField] private InventoryItem[] items;

    public event Action<ShardType> onItemUse;

    private void Awake()
    {
        _instance = this;

        foreach (InventoryItem item in items)
            item.Init(this);
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    private void Update()
    {
        // debug
        if (Input.GetKeyDown(KeyCode.Alpha1))
            items[0].UseItem();
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            items[1].UseItem();
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            items[2].UseItem();
    }

    public void OnItemPicked(ShardType type)
    {
        if (type == ShardType.small)
            items[0].PickItem();
        else if (type == ShardType.medium)
            items[1].PickItem();
        else if (type == ShardType.large)
            items[2].PickItem();
    }

    public void ItemUsed(ShardType type)
    {
        onItemUse?.Invoke(type);
    }
}
