using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private CharacterController _controller;
    private bool active = false;
    public GameObject inventory;
    public InventoryData inventoryObject;

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
        if (collider.GetComponent<IngredientInstance>())
        {
            var item = collider.GetComponent<IngredientInstance>();
            if (item && !item.gotIngredient)
            {
                inventoryObject.AddItem(item.data, 1);
                item.change();
            }
        }
        if (collider.GetComponent<PotionInstance>())
        {
            var item = collider.GetComponent<PotionInstance>();
            var potion = collider.GetComponent<MakePotion>();
            if (item && !item.gotPotion)
            {
                inventoryObject.AddItem(item.data, 1);
                potion.addToInventory();
                item.change();
            }
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