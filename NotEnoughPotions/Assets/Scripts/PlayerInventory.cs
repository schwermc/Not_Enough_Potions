using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private CharacterController _controller;
    private bool active = false;
    public GameObject inventory;
    public InventoryObject inventoryObject;

    void Awake()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            updateUI();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        var item = collider.GetComponent<IngredientInstance>();
        if (item && !item.gotIngredient)
        {
            inventoryObject.AddItem(item.data, 1);
            item.change();
        }
    }

    void updateUI()
    {
        if (!active)
        {
            active = true;
            Time.timeScale = 0f;
            inventory.SetActive(active);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            active = false;
            Time.timeScale = 1f;
            inventory.SetActive(active);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void OnApplicationQuit()
    {
        inventoryObject.Container.Clear();
    }
}
