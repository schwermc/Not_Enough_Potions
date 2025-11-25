using UnityEngine;

public class DisplayPotions : MonoBehaviour
{
    private bool collision = false;

    [SerializeField] PotionStationData stationData;
    [SerializeField] GameObject slots;

    void Start()
    {
        CreateDisplay();
    }

    public void SetCollision(bool boolean)
    {
        collision = boolean;
    }
    
    public bool GetCollision()
    {
        return collision;
    }

    internal void CreateDisplay()
    {
        for (int i = 0; i < stationData.Container.Count; i++)
        {
            var obj = Instantiate(stationData.Container[i].StationUiImage, Vector3.zero, Quaternion.identity, slots.transform);
            obj.GetComponent<ItemButtonUI>().setName(stationData.Container[i].ingredientName);
        }
    }
}
