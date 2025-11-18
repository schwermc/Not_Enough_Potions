using UnityEngine;

public class ItemData : ScriptableObject
{
    public string ingredientName;
    [TextArea(15, 10)]
    public string description;
    public float sellAmount;
    public GameObject UiImage;
    public GameObject StationUiImage;
}
