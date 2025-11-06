using UnityEngine;

public class WeekCounter : MonoBehaviour
{
    [SerializeField] static int weekCounter = 1;

    public void UpdateWeek()
    {
        weekCounter++;
        if (weekCounter > 7)
            weekCounter = 1;
    }

    public int GetWeekCounter() { return weekCounter; }
}
