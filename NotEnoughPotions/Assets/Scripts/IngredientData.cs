using UnityEngine;

[CreateAssetMenu(fileName = "newIngredient", menuName = "Item/Ingredient")]
public class IngredientData : ScriptableObject
{
    public string ingredientName;
    [TextArea(15, 10)]
    public string description;
    public IngredientType type;

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
