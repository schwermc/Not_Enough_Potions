using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public InventoryData inventory;

    private InventoryItem inventoryItem;
    private int ItemIndex;

    [SerializeField] ItemData item;
    [SerializeField] ShopData shopData;
    [SerializeField] Money money;

    public void Start()
    {
        shopData = GameObject.FindGameObjectWithTag("ShopStation").GetComponent<ShopData>();
        money = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Money>();
        inventoryItem = GetComponent<InventoryItem>();

        for (int i = 0; i < shopData.shopList.Count; i++)
        {
            if (inventoryItem.getName().text == shopData.shopList[i].itemInfo().name)
            {
                item = shopData.shopList[i].itemInfo();
                ItemIndex = i;
            }
        }
    }

    public void buyItem()
    {
        if (haveEnoughGoldToBuy())
        {
            inventory.AddItem(item, 1);
            money.SubGold(GetGoldAmount());
            money.updateGold();
        }
    }

    bool haveEnoughGoldToBuy()
    {
        if (inventory.Container.Count < 1)
            return false;

        if (checkIfCanBuyItem())
            return true;

        return false;
    }

    bool checkIfCanBuyItem()
    {
        if (shopData.shopList[ItemIndex].priceInfo() <= money.GetGold())
            return true;
        return false;
    }

    float GetGoldAmount() { return shopData.shopList[ItemIndex].priceInfo(); }
}
