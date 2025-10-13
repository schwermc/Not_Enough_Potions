using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Iventory", menuName = "Inventory")]
public class InventoryData : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemData _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].getItem() == _item)
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

    public void SubItem(ItemData _item, int _amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].getItem() == _item && Container[i].getAmount() >= Container[i].getAmount() + 0)
            {
                Container[i].SubAmount(_amount);
                break;
            }
        }
    }

    public int FindItem(ItemData _item)
    {
        int index = -1;
        for (int i = 0; i < Container.Count; i++)
        {
            if (_item == Container[i].getItem())
            {
                index = i;
            }
        }
        return index;
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemData item;
    public int amount;

    public InventorySlot(ItemData _item, int _amonut)
    {
        item = _item;
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

    public ItemData getItem()
    {
        return item;
    }

    public int getAmount()
    {
        return amount;
    }
}