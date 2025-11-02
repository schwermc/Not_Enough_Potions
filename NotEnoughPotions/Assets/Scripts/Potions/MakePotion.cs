using UnityEngine;

public class MakePotion : MonoBehaviour
{

    public InventoryData inventory;

    private bool check;

    bool checkList(PotionData potion)
    {
        bool notInList = false;
        int listAmount = 0;

        if (inventory.Container.Count < 1)
        {
            return false;
        }

        for (int i = 0; i < potion.Ingredients.Count; i++)
        {
            for (int j = 0; j < inventory.Container.Count; j++)
            {
                if (potion.Ingredients[i].item == inventory.Container[j].getItem())
                {
                    Debug.Log(potion.Ingredients[i].item + " : " + inventory.Container[j].item);
                    if (potion.Ingredients[i].amount > inventory.Container[j].getAmount())
                    {
                        Debug.Log(potion.Ingredients[i].amount + " : " + inventory.Container[j].getAmount());
                        return false;
                    }
                    notInList = false;
                    listAmount++;
                }
                else
                {
                    Debug.Log(potion.Ingredients[i].item + " : " + inventory.Container[j].getItem());
                    notInList = true;
                }
            }
        }

        if (notInList && listAmount != potion.Ingredients.Count)
        {
            return false;
        }

        return true;
    }

    public void addToInventory(PotionData potion, PotionInstance _item, int _amount)
    {
        check = checkList(potion);
        if (check)
        {
            for (int i = 0; i < potion.Ingredients.Count; i++)
            {
                inventory.SubItem(potion.Ingredients[i].item, potion.Ingredients[i].amount);
            }
            inventory.AddItem(_item.data, _amount);
            _item.change();
        }
    }

    public bool getCheck()
    {
        return check;
    }
}