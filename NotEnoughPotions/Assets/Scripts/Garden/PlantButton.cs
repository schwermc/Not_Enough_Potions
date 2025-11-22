using UnityEngine;
using UnityEngine.UI;


public class PlantButton : MonoBehaviour
{
    private GardenMenu gardenMenu;
    private GardenList gardenList;
    private GardenPlanter gardenPlanter;

    [SerializeField] ItemButtonUI buttonName;
    [SerializeField] InventoryData inventory;
    [SerializeField] GameObject gardenInfo;

    void Awake()
    {
        gardenInfo = GameObject.FindGameObjectWithTag("GardenPlanters");
        gardenMenu = gardenInfo.GetComponent<GardenMenu>();
        gardenList = gardenInfo.GetComponent<GardenList>();
    }

    void Update()
    {
        gardenPlanter = gardenMenu.returnGardenList()[gardenMenu.Index()];
        if (checkIfIventoryAsAmount())
        {
            SetButtonInterable(true);
        }

        if (!checkIfIventoryAsAmount())
        {
            SetButtonInterable(false);
        }
    }

    public void updatePot()
    {
        if (gardenMenu != null)
        {
            int correctPlant = plantIndexLocation();

            if (correctPlant != -1 && !checkIfPothasplant())
                    gardenPlanter.PotPlant(correctPlant);
        }
    }

    bool checkIfIventoryAsAmount()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (inventory.Container[i].getItem().ingredientName == buttonName.getName().text && inventory.Container[i].getAmount() > 0)
                return true;
        }

        return false;
    }

    bool checkIfPothasplant()
    {
        return gardenPlanter.GetGardenData().IsPlanted();
    }

    int plantIndexLocation()
    {
        for (int i = 0; i < gardenList.gardenList.Count; i++)
        {
            if(gardenList.gardenList[i].ingredientName == buttonName.getName().text)
                return i;
        }

        return -1;
    }

    void SetButtonInterable(bool set) { GetComponent<Button>().interactable = set; }
}
