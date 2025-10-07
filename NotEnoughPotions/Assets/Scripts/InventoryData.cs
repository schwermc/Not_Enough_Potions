using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Iventory", menuName = "Inventory")]
public class InventoryData : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(IngredientData _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].ingredient == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }

    public void SubItem(IngredientData _item, int _amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].ingredient == _item)
            {
                Container[i].SubAmount(_amount);
                break;
            }
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public IngredientData ingredient;
    public int amount;

    public InventorySlot(IngredientData _item, int _amonut)
    {
        ingredient = _item;
        amount = _amonut;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void SubAmount(int value)
    {
        amount -= value;
    }

    public IngredientData getIngredient()
    {
        return ingredient;
    }
}