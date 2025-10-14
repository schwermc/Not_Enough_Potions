using TMPro;
using UnityEngine;

public class ShopCounter : MonoBehaviour
{
    public InventoryData inventory;
    public CustomerCart customerCart;
    public GameObject popUp;
    private bool sellToCustomer = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && sellToCustomer)
        {
            SellPotion(customerCart.Container[0].item, customerCart.Container[0].amount);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            popUp.GetComponent<TMP_Text>().text = "Press C";
            popUp.SetActive(true);
            sellToCustomer = true;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            popUp.SetActive(false);
            sellToCustomer = false;
        }
    }

    void SellPotion(ItemData item, int amount)
    {
        int index = inventory.FindItem(item);
        if (index >= 0 && inventory.Container[index].amount > 0 && customerCart.soldTo == false)
        {
            inventory.SubItem(item, amount);
        }
    }
}
