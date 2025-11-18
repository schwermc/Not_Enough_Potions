using System.Collections.Generic;
using UnityEngine;

public class GardenMenu : MonoBehaviour
{
    private bool active = false;

    [SerializeField] PlayerInventory inventory;
    [SerializeField] GardenList gardenList;
    [SerializeField] GameObject gardenUI;
    [SerializeField] GameObject slots;
    [SerializeField] List<GardenPlanter> gardenPot = new List<GardenPlanter>();
    
    void Start()
    {
        CreateDisplay();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && AtPot())
        {
            if (inventory.getCheck()) 
                inventory.updateUI();
            updateUI();
        }
    }    

    public void updateUI()
    {
        if (!active)
        {
            active = true;
            Time.timeScale = 0f;
            gardenUI.SetActive(active);
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        if (active)
        {
            active = false;
            Time.timeScale = 1f;
            gardenUI.SetActive(active);
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
    }

    public bool getCheck()
    {
        return active;
    }

    void CreateDisplay()
    {
        for (int i = 0; i < gardenList.gardenList.Count; i++)
        {
            var obj = Instantiate(gardenList.gardenList[i].StationUiImage, Vector3.zero, Quaternion.identity, slots.transform);
            obj.GetComponent<ItemButtonUI>().setName(gardenList.gardenList[i].ingredientName);
        }
    }

    bool AtPot()
    {
        bool check = false;

        for (int i = 0; i < gardenPot.Count; i++)
        {
            if (gardenPot[i].AtPot())
            {
                check = true;
                break;
            }
        }

        return check;
    }
}