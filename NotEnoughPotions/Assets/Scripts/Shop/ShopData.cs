using System.Collections.Generic;
using UnityEngine;

public class ShopData : MonoBehaviour
{
    public List<shopInfo> shopList = new List<shopInfo>();

    private bool active = false;
    private ShopDisplay shopDisplay;

    [SerializeField] PlayerInventory inventory;
    [SerializeField] GameObject shopUI;

    public void Awake()
    {
        shopDisplay = shopUI.GetComponent<ShopDisplay>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && shopDisplay.GetCollision())
        {
            if (inventory.getCheck())
            {
                inventory.updateUI();
            }
            updateUI();
        }
    }

    void OnTriggerEnter() { shopDisplay.SetCollision(true); }
    void OnTriggerExit() { shopDisplay.SetCollision(false); }

    public void updateUI()
    {
        if (!active)
        {
            active = true;
            Time.timeScale = 0f;
            shopUI.SetActive(active);
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        if (active)
        {
            active = false;
            Time.timeScale = 1f;
            shopUI.SetActive(active);
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
    }

    public bool getCheck() { return active; }
}

[System.Serializable]
public class shopInfo
{
    [SerializeField] ItemData itemData;
    [SerializeField] float price;

    public void itemInfo(ItemData item)
    {
        itemData = item;
        price = itemData.sellAmount + 2;
    }
    public ItemData itemInfo() { return itemData; }

    public void priceInfo(int amount) { price = amount; }
    public float  priceInfo() { return price; }
}