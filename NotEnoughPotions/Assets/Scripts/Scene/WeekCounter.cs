using UnityEngine;

public class WeekCounter : MonoBehaviour
{
    [SerializeField] static int weekCounter = 1;

    public void UpdateWeek()
    {
        if (weekCounter <= 7)
            weekCounter++;
        if (7 < weekCounter)
            weekCounter = 1;
    }

    public int GetWeekCounter() { return weekCounter; }
}
