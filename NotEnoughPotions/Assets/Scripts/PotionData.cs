using UnityEngine;

[CreateAssetMenu(fileName = "newPotion", menuName = "Item/Potion")]
public class PotiontData : ScriptableObject
{
    public string ingredientName;
    [TextArea(15, 10)]
    public string description;

    public GameObject UIimage;
    public GameObject model;
}
