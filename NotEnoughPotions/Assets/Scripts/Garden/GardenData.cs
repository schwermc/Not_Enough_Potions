using UnityEngine;

[CreateAssetMenu(fileName = "newGarden", menuName = "Item/Garden")]
public class GardenData : ScriptableObject
{
    [SerializeField] bool isPlanted = false;
    [SerializeField] bool isGrown = false;
    [SerializeField] IngredientData plant;

    public void IsPlanted(bool condition)
    {
        isPlanted = condition;
    }

    public void IsGrown(bool condition)
    {
        isGrown = condition;
    }

    public bool IsPlanted() { return isPlanted; }
    public bool IsGrown() { return isGrown; }

    public void changePlant(IngredientData newPlant)
    {
        plant = newPlant;
    }

    public void removePlant()
    {
        plant = null;
    }
}
