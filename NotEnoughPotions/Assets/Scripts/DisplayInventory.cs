using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventoryObject;
    public GridLayoutGroup gridLayout;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        CreateDisplay();
    }

    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventoryObject.Container.Count; i++)
        {
            var obj = Instantiate(inventoryObject.Container[i].ingredient.UIimage, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = new Vector3();
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventoryObject.Container[i].amount.ToString("n0");
            obj.GetComponentInChildren<TextMeshProUGUI>().text = "hello";
            itemsDisplayed.Add(inventoryObject.Container[i], obj);
        }
    }

    void UpdateDisplay()
    {
        for (int i = 0; i < inventoryObject.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventoryObject.Container[i]))
            {
                itemsDisplayed[inventoryObject.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventoryObject.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventoryObject.Container[i].ingredient.UIimage, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = new Vector3();
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventoryObject.Container[i].amount.ToString("n0");
                obj.GetComponentInChildren<TextMeshProUGUI>().text = "Jimmy";
                itemsDisplayed.Add(inventoryObject.Container[i], obj);
            }
        }
    }
}
