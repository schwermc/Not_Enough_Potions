using System.Collections.Generic;
using UnityEngine;

public class MakePotion : MonoBehaviour
{

    public InventoryData inventory;
    public List<IngredientInfo> Container = new List<IngredientInfo>();

    bool checkList()
    {
        bool notInList = false;
        int listAmount = 0;

        if (inventory.Container.Count < 1)
        {
            return false;
        }

        for (int i = 0; i < Container.Count; i++)
        {
            for (int j = 0; j < inventory.Container.Count; j++)
            {
                if (Container[i].item == inventory.Container[j].item)
                {
                    // Debug.Log(Container[i].item + " : " + inventory.Container[j].item);
                    if (Container[i].amount > inventory.Container[j].amount)
                    {
                        // Debug.Log(Container[i].amount + " : " + inventory.Container[j].amount);
                        return false;
                    }
                    notInList = false;
                    listAmount++;
                }
                else
                {
                    // Debug.Log(Container[i].item + " : " + inventory.Container[j].item);
                    notInList = true;
                }
            }
        }

        if (notInList && listAmount != Container.Count)
        {
            return false;
        }

        return true;
    }

    public void addToInventory(PotionInstance _item, int _amount)
    {
        bool check = checkList();
        // Debug.Log(check);
        if (check)
        {
            for (int i = 0; i < Container.Count; i++)
            {
                inventory.SubItem(Container[i].item, Container[i].amount);
            }
            inventory.AddItem(_item.data, _amount);
            _item.change();
        }
    }
}

[System.Serializable]
public class IngredientInfo
{
    public ItemData item;
    public int amount;
}