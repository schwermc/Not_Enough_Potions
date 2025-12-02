using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cart", menuName = "List/Cart")]
public class CartList : ScriptableObject
{
    public List<ItemData> list = new List<ItemData>();
}
