using UnityEngine;

public class ShopDisplay : MonoBehaviour
{
    private bool collision = false;

    [SerializeField] ShopData shopData;
    [SerializeField] GameObject slots;

    void Start()
    {
        CreateDisplay();
    }

    public void SetCollision(bool boolean)
    {
        collision = boolean;
    }
    
    public bool GetCollision()
    {
        return collision;
    }

    internal void CreateDisplay()
    {
        for (int i = 0; i < shopData.shopList.Count; i++)
        {
            var obj = Instantiate(shopData.shopList[i].itemInfo().ShopUiImage, Vector3.zero, Quaternion.identity, slots.transform);
            obj.GetComponent<InventoryItem>().setName(shopData.shopList[i].itemInfo().ingredientName);
            obj.GetComponent<InventoryItem>().setAmount((int)shopData.shopList[i].priceInfo());
        }
    }
}
