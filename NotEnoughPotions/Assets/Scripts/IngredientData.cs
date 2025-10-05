using UnityEngine;

[CreateAssetMenu(fileName = "newIngredient", menuName = "Item/Ingredient")]
public class IngredientData : ScriptableObject
{
    [TextArea(15, 10)]
    public string description;
    public IngredientType type;

    // public Sprite image;
    public GameObject UIimage;
    public GameObject model;
}

public enum IngredientType
{
    Plant,
    Metal,
    Toxin,
    Natural
}
