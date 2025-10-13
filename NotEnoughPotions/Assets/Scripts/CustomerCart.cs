using System.Collections.Generic;
using UnityEngine;

public class CustomerCart : MonoBehaviour
{
    public InventoryData inventory;
    public List<CartItem> Container = new List<CartItem>();
}


[System.Serializable]
public class CartItem
{
    public ItemData item;
    public int amount;
}