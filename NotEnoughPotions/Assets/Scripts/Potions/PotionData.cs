using UnityEngine;

[CreateAssetMenu(fileName = "newPotion", menuName = "Item/Potion")]
public class PotiontData : ItemData
{
    public PotionType type;
}

public enum PotionType
{
    Enhancing,
    Emotion,
    Regeneration,
    Elemental
}
