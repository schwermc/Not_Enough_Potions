using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    private static float gold = 30f;
    private const float startingGold = 30f;

    [SerializeField] WeekCounter weekCounter;
    [SerializeField] TMP_Text text;
    [SerializeField] TMP_Text wintext;
    [SerializeField] float neededGold = 0;

    void Start()
    {
        if (weekCounter.GetWeekCounter() == 1)
            gold = startingGold;
        updateGold();
        wintext.text = "/  " + neededGold.ToString() + " G";
    }

    public void AddGold(float amount) { gold += amount; }
    public void SubGold(float amount) { gold -= amount; }
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
