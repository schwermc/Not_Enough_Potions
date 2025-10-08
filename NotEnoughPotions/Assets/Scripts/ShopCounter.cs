using UnityEngine;

public class ShopCounter : MonoBehaviour
{
    public GameObject potion;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            potion.SetActive(false);
        }
    }
}
