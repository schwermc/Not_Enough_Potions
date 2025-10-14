using UnityEngine;

[CreateAssetMenu(fileName = "newIngredient", menuName = "Item/Ingredient")]
public class IngredientData : ItemData
{
    public IngredientType type;
}

public enum IngredientType
{
    Plant,
    Metal,
    Toxin,
    Natural
}
