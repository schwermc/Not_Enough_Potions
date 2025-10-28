using UnityEngine;

[CreateAssetMenu(fileName = "Settings Info", menuName = "Settings Info")]
public class Settings : ScriptableObject
{
    public float currentDIP;

    public void setDIP(float amount)
    {
        currentDIP = amount;
    }

    public float getDIP()
    {
        return currentDIP;
    }
}