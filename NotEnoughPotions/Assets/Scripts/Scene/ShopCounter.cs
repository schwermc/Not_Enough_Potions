using TMPro;
using UnityEngine;

public class ShopCounter : MonoBehaviour
{
    public InventoryData inventory;
    public GameObject customer;
    public GameObject popUp;
    private bool atCounter = false;
    private bool soldToCurrent = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && atCounter)
        {
            SellCart(customer.GetComponent<CustomerCart>());
        }

        if (atCounter && !soldToCurrent)
        {
            popUp.SetActive(true);
        }
        if (!atCounter || soldToCurrent)
        {
            popUp.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            popUp.GetComponent<TMP_Text>().text = "Press C";
            atCounter = true;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            atCounter = false;
        }
    }

    void SellPotion(ItemData item, int amount)
    {
        int index = inventory.FindItem(item);
        if (index >= 0 && inventory.Container[index].amount > 0)
        {
            inventory.SubItem(item, amount);
        }
    }

    void SellCart(CustomerCart cart)
    {
        bool check = CanSell(cart);
        // Debug.Log(check);
        if (!cart.soldTo && check)
        {
            for (int i = 0; i < cart.Container.Count; i++)
            {
                SellPotion(cart.Container[i].item, cart.Container[i].amount);
            }
            soldToCurrent = true;
            cart.soldTo = true;
        }
    }

    bool CanSell(CustomerCart cart)
    {
        bool canSellCart = false;
        int cartAmount = 0;

        if (cart.Container.Count < 1)
        {
            return false;
        }

        for (int i = 0; i < cart.Container.Count; i++)
        {
            for (int j = 0; j < inventory.Container.Count; j++)
            {
                if (cart.Container[i].item == inventory.Container[j].getItem())
                {
                    // Debug.Log(cart.Container[i].item + " : " + inventory.Container[j].item);
                    if (cart.Container[i].amount > inventory.Container[j].getAmount())
                    {
                        // Debug.Log(cart.Container[i].amount + " : " + inventory.Container[j].getAmount());
                        return false;
                    }
                    canSellCart = true;
                    cartAmount++;
                }

                if (cart.Container[i].item != inventory.Container[j].getItem())
                {
                    // Debug.Log(cart.Container[i].item + " : " + inventory.Container[j].getItem());
                    canSellCart = false;
                }
            }
        }

        if (!canSellCart && cartAmount != cart.Container.Count)
        {
            return false;
        }

        return true;
    }
}
