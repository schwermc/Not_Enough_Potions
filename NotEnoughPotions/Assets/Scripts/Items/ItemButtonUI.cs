using TMPro;
using UnityEngine;

public class ItemButtonUI : MonoBehaviour
{
    [SerializeField] TMP_Text item;

    public void setName(string item)
    {
        this.item.text = item;
    }

    public TMP_Text getName()
    {
        return item;
    }
}
