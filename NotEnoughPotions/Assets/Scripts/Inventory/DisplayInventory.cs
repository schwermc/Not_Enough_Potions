using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryData inventoryData;
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
        for (int i = 0; i < inventoryData.Container.Count; i++)
        {
            var obj = Instantiate(inventoryData.Container[i].item.UIimage, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = new Vector3();
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventoryData.Container[i].amount.ToString("n0");
            obj.GetComponentInChildren<TextMeshProUGUI>().text = "hello";
            itemsDisplayed.Add(inventoryData.Container[i], obj);
        }
    }

    void UpdateDisplay()
    {
        for (int i = 0; i < inventoryData.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventoryData.Container[i]))
            {
                itemsDisplayed[inventoryData.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventoryData.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventoryData.Container[i].item.UIimage, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = new Vector3();
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventoryData.Container[i].amount.ToString("n0");
                obj.GetComponentInChildren<TextMeshProUGUI>().text = "Jimmy";
                itemsDisplayed.Add(inventoryData.Container[i], obj);
            }
        }
    }
}
