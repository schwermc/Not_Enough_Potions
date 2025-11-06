using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    private static float gold = 0f;
    [SerializeField] TMP_Text text;

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
}
