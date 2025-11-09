using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    private static float gold = 0f;
    [SerializeField] TMP_Text text;
    [SerializeField] float neededGold = 0;

    void Start()
    {
        updateGold();
    }

    public void AddGold(float amount) {gold += amount; }
    public float GetGold() { return gold; }

    public void updateGold()
    {
        text.text = gold.ToString();
    }

    public bool HaveEnoughGold()
    {
        return (neededGold <= gold) ? true : false;
    }
}
