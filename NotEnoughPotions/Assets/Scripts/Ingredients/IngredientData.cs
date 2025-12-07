using UnityEngine;

[CreateAssetMenu(fileName = "newIngredient", menuName = "Item/Ingredient")]
public class IngredientData : ItemData
{
    public IngredientType type;
    public int HarvestAmount = 1;

    public override string GetItemType() { return type.ToString(); }
}

public enum IngredientType
{
    Plant,
    Metal,
    Toxin,
    Natural
}
