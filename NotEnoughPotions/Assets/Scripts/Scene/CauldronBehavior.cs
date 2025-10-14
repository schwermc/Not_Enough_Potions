using UnityEngine;

public class CauldronBehavior : MonoBehaviour
{
    public InventoryData inventory;
    private ItemData potion;
    private Transform trans;
    private bool doneToday = false;

    void Start()
    {
        trans = GetComponent<Transform>();
        potion = GetComponent<ItemData>();
    }

    public void OnTriggerEnter(Collider collider)
    {
        bool check = makePotionCheck(collider, 0);
        if (check)
        {
            var item = inventory.Container[0].getItem();
            inventory.SubItem(item, 1);
            inventory.AddItem(potion, 1);
            doneToday = true;
            trans.localScale = new Vector3(.5f, .5f, .5f);
        }
    }

    bool makePotionCheck(Collider collider, int index) {
        bool check = false;
        if (collider.tag == "Player" && !doneToday && inventory.Container.Count > 0 && inventory.Container[index].getAmount() > 0)
        {
            check = true;
        }
        return check;
    }
    
}
