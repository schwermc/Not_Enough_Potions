using UnityEngine;

public class GardenPlanter : MonoBehaviour
{
    private bool atPot = false;

    [SerializeField] string playerTag;
    [SerializeField] GameObject popup;
    [SerializeField] InventoryData inventory;

    [Header("Garden Pot")]
    [SerializeField] Renderer _material;
    [SerializeField] GardenList gardenList;
    [SerializeField] GardenData gardenData;
    [SerializeField] Material notPlanted;
    [SerializeField] Material notGrown;
    [SerializeField] Material isGrown;

    void Start()
    {
        popup.SetActive(false);
        if (gardenData.IsPlanted())
        {
            gardenData.IsGrown(true);
        }
        setGrown();
    }

    void Update()
    {
        popup.transform.rotation = Quaternion.LookRotation(popup.transform.position - Camera.main.transform.position);

        if (Input.GetKeyDown(KeyCode.E) && Planted(gardenData.IsPlanted()))
        {
            AddPlant(gardenList.gardenList[0]);
        }

        if (Input.GetKeyDown(KeyCode.E) && Planted(!gardenData.IsGrown()))
        {
            gardenData.harvestPlant(inventory);
            setGrown();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == playerTag && (!gardenData.IsPlanted() || gardenData.IsGrown()))
        {
            popup.SetActive(true);
            atPot = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == playerTag)
        {
            popup.SetActive(false);
            atPot = false;
        }
    }

    public void AddPlant(IngredientData ingredient)
    {
        if (gardenList.gardenList.Contains(ingredient) && IngredientCheck(ingredient))
        {
            inventory.SubItem(ingredient, 1);
            gardenData.changePlant(ingredient);
            setGrown();
        }
    }

    void setGrown()
    {
        if (!gardenData.IsPlanted())
        {
            _material.material = notPlanted;
            return;
        }
        if (!gardenData.IsGrown())
        {
            _material.material = notGrown;
            return;
        }
        if (gardenData.IsGrown())
        {
            _material.material = isGrown;
            return;
        }
    }

    bool Planted(bool condition1 = false)
    {
        if (!atPot || condition1)
            return false;
        return true;
    }

    bool IngredientCheck(IngredientData ingredient)
    {
        bool check = false;
        for (int i = 0; i < inventory.Container.Count; i ++)
        {
            if (inventory.Container[i].item == ingredient && inventory.Container[i].amount > 0)
                check = true;
        }
        return check;
    }
}
