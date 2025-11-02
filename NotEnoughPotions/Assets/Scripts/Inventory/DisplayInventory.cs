using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] InventoryData inventory;
    [SerializeField] Dictionary<InventorySlot, InventoryItem> Container = new Dictionary<InventorySlot, InventoryItem>();
    [SerializeField] GameObject slots;

    void Start()
    {
        UpdateDisplay();
    }

    void Update()
    {
        UpdateDisplay();
    }
    
    void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (Container.ContainsKey(inventory.Container[i]))
            {
                Container[inventory.Container[i]].setAmount(inventory.Container[i].getAmount());
            }
            if (!Container.ContainsKey(inventory.Container[i]))
            {
                var obj = Instantiate(inventory.Container[i].item.UiImage, Vector3.zero, Quaternion.identity, slots.transform);
                obj.GetComponent<InventoryItem>().setAmount(inventory.Container[i].getAmount());
                obj.GetComponent<InventoryItem>().setName(inventory.Container[i].getItem().ingredientName);
                Container.Add(inventory.Container[i], obj.GetComponent<InventoryItem>());
            }
        }
    }

}