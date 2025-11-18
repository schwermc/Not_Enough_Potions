using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPotion", menuName = "Item/Potion")]
public class PotionData : ItemData
{
    public PotionType type;
    public List<IngredientInfo> Ingredients = new List<IngredientInfo>();

    private string list;

    public string ListIngredients()
    {
        list = "";
        for (int i = 0; i < Ingredients.Count; i++)
        {
            if (i % 2 == 0 && i != 0)
                list += "\n";
            list += Ingredients[i].item.ingredientName + ": " + Ingredients[i].amount + "\t\t";
        }
        return list;
    }
}

public enum PotionType
{
    Enhancing,
    Emotion,
    Regeneration,
    Elemental
}

[System.Serializable]
public class IngredientInfo
{
    public IngredientData item;
    public int amount;
}