using UnityEngine;

public class GardenPlanter : MonoBehaviour
{
    private Renderer _material;
    [SerializeField] string playerTag;
    [SerializeField] InventoryData inventoryObject;
    [SerializeField] GameObject popup;

    [Header("Garden Pot")]
    [SerializeField] GardenList gardenList;
    [SerializeField] GardenData gardenData;
    [SerializeField] Material notPlanted;
    [SerializeField] Material notGrown;
    [SerializeField] Material isGrown;

    void Start()
    {
        popup.SetActive(false);
        _material = GetComponent<Renderer>();
        setGrown();

    }

    void Update()
    {
        popup.transform.rotation = Quaternion.LookRotation(popup.transform.position - Camera.main.transform.position);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == playerTag)
            popup.SetActive(true);
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == playerTag)
            popup.SetActive(false);
    }

    public void AddPlant(IngredientData ingredient)
    {
        if (gardenList.gardenList.Contains(ingredient))
        {
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
}
