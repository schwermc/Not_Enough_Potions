using UnityEngine;

public class WeekCounter : MonoBehaviour
{
    private static int weekAmount = 0;
    [SerializeField] static int weekCounter = 1;

    public void UpdateWeek()
    {
        weekCounter++;
        if (weekCounter > 7)
        {
            weekCounter = 1;
            weekAmount++;
        }
    }

    public int GetWeekCounter() { return weekCounter; }
    public int GetCurrentWeek() { return weekAmount; }
}
