using UnityEngine;

public class WeekCounter : MonoBehaviour
{
    private static int dayCounter = 1;
    private static bool newWeek = true;
    [SerializeField] static int weekCounter = 1;

    public void UpdateWeek()
    {
        Debug.Log(dayCounter);
        newWeek = false;
        dayCounter++;
        if (dayCounter > 7)
        {
            dayCounter = 1;
            weekCounter++;
            newWeek = true;
        }
    }

    public int GetWeekCounter() { return weekCounter; }
    public int GetCurrentDay() { return dayCounter; }

    public bool NewWeek() { return newWeek; }

    public void RestartCount() { dayCounter = 1; weekCounter = 1;  newWeek = true; }
}
