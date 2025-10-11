using System.Collections.Generic;
using UnityEngine;

public class MakePotion : MonoBehaviour
{

    public InventoryData inventory;
    public List<IngredientInfo> Container = new List<IngredientInfo>();

    public void addToInventory()
    {
        Debug.Log("Enter");
        for (int i = 0; i < Container.Count; i++)
        {
            inventory.SubItem(Container[i].item, Container[i].amount);
        }
    }
}

[System.Serializable]
public class IngredientInfo
{
    public ItemData item;
    public int amount;
}