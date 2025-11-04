using System.Collections.Generic;
using UnityEngine;

public class PotionStationData : MonoBehaviour
{
    public List<PotionData> Container = new List<PotionData>();

    private DisplayPotions displayPotions;
    private bool active = false;

    [SerializeField] PlayerInventory inventory;
    [SerializeField] GameObject potionUI;

    void Start()
    {
        displayPotions = potionUI.GetComponent<DisplayPotions>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && displayPotions.GetCollision())
        {
            if (inventory.getCheck()) 
                inventory.updateUI();
            updateUI();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        displayPotions.SetCollision(true);
    }

    void OnTriggerExit(Collider collider)
    {
        displayPotions.SetCollision(false);
    }
    
    public void updateUI()
    {
        if (!active)
        {
            active = true;
            Time.timeScale = 0f;
            potionUI.SetActive(active);
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        if (active)
        {
            active = false;
            Time.timeScale = 1f;
            potionUI.SetActive(active);
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
    }

    public bool getCheck()
    {
        return active;
    }
}
