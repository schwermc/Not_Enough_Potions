using TMPro;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] TMP_Text item;
    [SerializeField] TMP_Text amount;

    public void setName(string item)
    {
        this.item.text = item;
    }

    public void setAmount(int amount)
    {
        this.amount.text = amount.ToString("n0");
    }

    public TMP_Text getName()
    {
        return item;
    }

    public TMP_Text getAmount()
    {
        return amount;
    }
}