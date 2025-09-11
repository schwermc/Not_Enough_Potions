using UnityEngine;

[CreateAssetMenu(fileName = "newIngredient", menuName = "Ingredient")]
public class IngredientData : ScriptableObject
{
    public string description;
    public string ingredientType;

    // UI display
    public Sprite image;
    // Scene / object display;
    public GameObject model;
}
