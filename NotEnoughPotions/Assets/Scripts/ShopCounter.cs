using UnityEngine;

public class ShopCounter : MonoBehaviour
{
    public InventoryData inventory;
    public CustomerCart customerCart;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            SellPotion(customerCart.Container[0].item, customerCart.Container[0].amount);
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
}
