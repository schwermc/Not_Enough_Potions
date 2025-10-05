using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIventory", menuName = "Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(IngredientData _ingredient, int _amount)
    {
        bool hasIngredient = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].ingredient == _ingredient)
            {
                Container[i].AddAmount(_amount);
                hasIngredient = true;
                break;
            }
        }
        if (!hasIngredient)
        {
            Container.Add(new InventorySlot(_ingredient, _amount));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public IngredientData ingredient;
    public int amount;

    public InventorySlot(IngredientData _ingredient, int _amount)
    {
        ingredient = _ingredient;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void SubAmount(int value)
    {
        amount -= value;
    }
}