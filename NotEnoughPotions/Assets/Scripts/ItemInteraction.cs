using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    [SerializeField] InventoryData inventoryObject;
    private bool inTrigger = false;

    void Update()
    {
        popUp.transform.rotation = Quaternion.LookRotation(popUp.transform.position - Camera.main.transform.position);

        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            pickedUp();
        }
    }

    void OnTriggerEnter()
    {
        inTrigger = true;
    }

    void OnTriggerExit()
    {
        inTrigger = false;
    }

    void pickedUp()
    {
        bool check = false;
        if (this.GetComponent<IngredientInstance>())
        {
            var item = this.GetComponent<IngredientInstance>();
            if (item && !item.gotIngredient)
            {
                inventoryObject.AddItem(item.data, 1);
                item.change();
                check = true;
            }
        }
        
        if (check)
            popUp.SetActive(false);
    }
}