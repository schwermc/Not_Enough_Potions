using UnityEngine;

public class UpdatePotionPrice : MonoBehaviour
{
    [SerializeField] CartList potions;

    public void Start()
    {
        for (int i = 0; i < potions.list.Count; i++)
        {
            potions.list[i].UpdatePrice();
        }
    }
}
