using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCounter : MonoBehaviour
{
    public InventoryData inventory;
    public GameObject customer;
    public GameObject popUp;
    private bool atCounter = false;
    private bool soldToCurrent = false;
    private bool sellCheck = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && atCounter && sellCheck && !soldToCurrent)
        {
            SellCart(customer.GetComponent<CustomerCart>());
            customer.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.C) && atCounter && !sellCheck && !soldToCurrent)
        {
            customer.SetActive(false);
            soldToCurrent = true;
        }

        if (atCounter && !soldToCurrent)
        {
            changeUI(popUp.GetComponent<TMP_Text>());
            popUp.SetActive(true);
        }
        
        if (!atCounter || soldToCurrent || customer.activeSelf == false)
        {
            popUp.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            atCounter = true;
            sellCheck = CanSell(customer.GetComponent<CustomerCart>());
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            atCounter = false;
        }
    }

    void changeUI (TMP_Text text)
    {
        if (atCounter && sellCheck)
            text.text = "Press C to sell";
        if (atCounter && !sellCheck)
            text.text = "Press C to refuse";
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
        if (!cart.soldTo && sellCheck)
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
