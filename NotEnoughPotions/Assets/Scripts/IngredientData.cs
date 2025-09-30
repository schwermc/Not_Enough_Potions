using UnityEngine;

[CreateAssetMenu(fileName = "newIngredient", menuName = "Item/Ingredient")]
public class IngredientData : ScriptableObject
{
    [TextArea(15, 10)]
    public string description;
    public IngredientType type;

    // UI display
    public Sprite image;
    // Scene / object display;
    public GameObject model;
}

public enum IngredientType
{
    Plant,
    Metal,
    Toxin,
    Natural
}
