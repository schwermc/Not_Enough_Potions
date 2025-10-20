using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCounter : MonoBehaviour
{
    public InventoryData inventory;
    public GameObject customer;
    public GameObject popUpSell;
    public GameObject popUpRefuse;
    private bool atCounter = false;
    private bool soldToCurrent = false;
    private bool sellCheck = false;

    void Start()
    {
        popUpSell.GetComponent<TMP_Text>().text = "Press E to sell";
        popUpRefuse.GetComponent<TMP_Text>().text = "Press Q to refuse";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && atCounter && sellCheck && !soldToCurrent)
        {
            SellCart(customer.GetComponent<CustomerCart>());
            customer.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q) && atCounter && !sellCheck && !soldToCurrent)
        {
            customer.SetActive(false);
            soldToCurrent = true;
        }

        if (atCounter && !soldToCurrent)
        {
            if (sellCheck)
                popUpSell.SetActive(true);
            popUpRefuse.SetActive(true);
        }
        
        if (!atCounter || soldToCurrent || customer.activeSelf == false)
        {
            popUpSell.SetActive(false);
            popUpRefuse.SetActive(false);
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
