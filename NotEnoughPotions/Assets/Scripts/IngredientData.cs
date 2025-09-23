using UnityEngine;

[CreateAssetMenu(fileName = "newIngredient", menuName = "Ingredient")]
public class IngredientData : ScriptableObject
{
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
