using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool active = false;

    [SerializeField] GameObject inventory;
    [SerializeField] PotionStationData station;
    [SerializeField] GardenMenu garden;
    [SerializeField] ShopData shop;
    [SerializeField] InventoryData playerInventory;
    [SerializeField] CartList startingInventory;
    [SerializeField] WeekCounter weekCounter;

    public void Start()
    {
        if (weekCounter.NewWeek() && weekCounter.GetWeekCounter() == 1)
            ClearInventory();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (station.getCheck())
                station.updateUI();
            if (garden.getCheck())
                garden.updateUI();
            if (shop.getCheck())
                shop.updateUI();
            updateUI();
        }
    }

    public void updateUI()
    {
        if (!active)
        {
            active = true;
            Time.timeScale = 0f;
            inventory.SetActive(active);
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        if (active)
        {
            active = false;
            Time.timeScale = 1f;
            inventory.SetActive(active);
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
    }

    void OnApplicationQuit()
    {
        ClearInventory();
    }

    internal void ClearInventory()
    {
        playerInventory.Container.Clear();
        for (int i = 0; i < startingInventory.list.Count; i++)
        {
            InventorySlot newSlot = new InventorySlot(startingInventory.list[i], 1);
            playerInventory.Container.Add(newSlot);
        }
    }

    public bool getCheck()
    {
        return active;
    }
}