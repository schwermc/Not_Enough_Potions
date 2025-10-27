using System.Collections.Generic;
using UnityEngine;

public class CustomerCart : MonoBehaviour
{
    public InventoryData inventory;
    public List<CartItem> Container = new List<CartItem>();
    public bool soldTo = false;
}


[System.Serializable]
public class CartItem
{
    [SerializeField] ItemData item;
    [SerializeField] int amount;

    public ItemData getItem()
    {
        return item;
    }

    public int getAmount()
    {
        return amount;
    }
}