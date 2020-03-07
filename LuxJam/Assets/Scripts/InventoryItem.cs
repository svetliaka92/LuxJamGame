using UnityEngine;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _quantityText;

    [SerializeField] private ShardType _shardType;
    [SerializeField] private int _quantity = 0;

    private Inventory parentInventory;

    public void Init(Inventory inventory)
    {
        parentInventory = inventory;

        UpdateQuantity();
    }

    public void PickItem()
    {
        _quantity++;

        UpdateQuantity();
    }

    public void UseItem()
    {
        if (_quantity > 0)
        {
            parentInventory.ItemUsed(_shardType);

            _quantity--;

            UpdateQuantity();
        }
    }

    private void UpdateQuantity()
    {
        if (_quantity > 0)
            _quantityText.text = _quantity.ToString();
        else
            _quantityText.text = "";
    }
}
