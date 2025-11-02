using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPotion", menuName = "Item/Potion")]
public class PotionData : ItemData
{
    public GameObject StationUiImage;
    public PotionType type;
    public List<IngredientInfo> Ingredients = new List<IngredientInfo>();
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