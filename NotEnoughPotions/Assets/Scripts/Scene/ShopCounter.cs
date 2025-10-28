using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopCounter : MonoBehaviour
{
    public InventoryData inventory;
    public List<GameObject> customer = new List<GameObject>();
    public GameObject popUpSell;
    public GameObject popUpRefuse;
    public bool finishDay = false;

    private TMP_Text sellText;
    private TMP_Text refuseText;
    private bool atCounter = false;
    private bool soldToCurrent = false;
    private bool sellCheck = false;
    private int currentCustomer = 0;

    [SerializeField] PlayerInventory inventoryCheck;

    void Start()
    {
        sellText = popUpSell.GetComponent<TMP_Text>();
        sellText.text = "Press X to sell";
        refuseText = popUpRefuse.GetComponent<TMP_Text>();
        refuseText.text = "Press Z to refuse";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && atCounter && sellCheck && !soldToCurrent && !inventoryCheck.getCheck())
        {
            SellCart(customer[currentCustomer].GetComponent<CustomerCart>());
            SwitchCustomer();
        }

        if (Input.GetKeyDown(KeyCode.Z) && atCounter && !soldToCurrent && !inventoryCheck.getCheck())
        {
            SwitchCustomer();
        }

        if (atCounter && !soldToCurrent)
        {
            if (sellCheck)
                popUpSell.SetActive(true);
            popUpRefuse.SetActive(true);
        }
        
        if (!atCounter || soldToCurrent)
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
            sellCheck = CanSell(customer[currentCustomer].GetComponent<CustomerCart>());
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
                SellPotion(cart.Container[i].getItem(), cart.Container[i].getAmount());
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
                if (cart.Container[i].getItem() == inventory.Container[j].getItem())
                {
                    if (cart.Container[i].getAmount() > inventory.Container[j].getAmount())
                    {
                        return false;
                    }
                    canSellCart = true;
                    cartAmount++;
                }

                if (cart.Container[i].getItem() != inventory.Container[j].getItem())
                {
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

    void SwitchCustomer()
    {
        soldToCurrent = true;
        atCounter = false;

        if (currentCustomer < customer.Count)
        {
            customer[currentCustomer].SetActive(false);
            currentCustomer++;
        }

        if (currentCustomer < customer.Count)
        {
            customer[currentCustomer].SetActive(true);
            soldToCurrent = false;
        }

        if (currentCustomer == customer.Count)
            finishDay = true;
    }
}
