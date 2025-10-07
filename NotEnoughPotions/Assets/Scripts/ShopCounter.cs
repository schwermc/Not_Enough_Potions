using UnityEngine;

public class ShopCounter : MonoBehaviour
{
    public GameObject potion;
    public LoadScene endDay;

    void Start() {
        endDay = GameObject.Find("_GameManager").GetComponent<LoadScene>();
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            potion.SetActive(false);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            endDay.endDay();
        }
    }
}
