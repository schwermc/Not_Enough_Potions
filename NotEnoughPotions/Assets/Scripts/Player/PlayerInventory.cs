using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool active = false;
    [SerializeField] GameObject inventory;
    [SerializeField] PotionStationData station;
    [SerializeField] InventoryData inventoryObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (station.getCheck())
                station.updateUI();
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
        inventoryObject.Container.Clear();
    }

    public bool getCheck()
    {
        return active;
    }
}