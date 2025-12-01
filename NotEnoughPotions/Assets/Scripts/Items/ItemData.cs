using UnityEngine;

public class ItemData : ScriptableObject
{
    public string ingredientName;
    [TextArea(15, 10)]
    public string description;
    public float sellAmount;
    public GameObject UiImage;
    public GameObject ShopUiImage;
    public GameObject StationUiImage;

    public virtual void UpdatePrice()
    {
        if (sellAmount < 1)
            sellAmount = 1;
    }
}
