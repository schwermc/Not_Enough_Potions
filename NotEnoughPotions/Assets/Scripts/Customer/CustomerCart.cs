using System.Collections.Generic;
using UnityEngine;

public class CustomerCart : MonoBehaviour
{
    public InventoryData inventory;
    public List<CartItem> Container = new List<CartItem>();
    public CartList potions;
    public CartList plantIngredients;
    public CartList nonplantIngredients;
    public bool soldTo = false;

    void Awake()
    {
        int listSize = Random.Range(1, 4);
        for (int i = 0; i < listSize; i++)
        {
            CartItem newItem = MakeCartItem();
            if (Container.Count > 0 && isItemInContainer(newItem.getItem()))
                continue;
            Container.Add(newItem);
        }
    }

    public CartItem MakeCartItem()
    {
        CartItem item = new CartItem();
        int cartListChoose = Random.Range(0, 3);
        int number;

        if (cartListChoose == 0) // potions
        {
            number = Random.Range(0, potions.list.Count);
            item.setItem(potions.list[number]);
            item.setAmount(Random.Range(1, 3));
        }

        if (cartListChoose == 1) // plants
        {
            number = Random.Range(0, plantIngredients.list.Count);
            item.setItem(plantIngredients.list[number]);
            item.setAmount(Random.Range(1, 5));
        }

        if (cartListChoose == 2) // non-plants
        {
            number = Random.Range(0, nonplantIngredients.list.Count);
            item.setItem(nonplantIngredients.list[number]);
            item.setAmount(1);
        }

        return item;
    }

    bool isItemInContainer(ItemData item)
    {
        for(int i = 0; i < Container.Count; i++)
        {
            if (Container[i].getItem().ingredientName == item.ingredientName)
                return true;
        }
        return false;
    }
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

    public void setItem(ItemData item)
    {
        this.item = item;
    }

    public void setAmount(int amount)
    {
        this.amount = amount;
    }
}