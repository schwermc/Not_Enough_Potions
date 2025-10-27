using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public ShopCounter finishDay;
    public GameObject endDayUI;
    private TMP_Text text;
    [SerializeField] PlayerInventory inventoryCheck;

    void Start()
    {
        text = endDayUI.GetComponent<TMP_Text>();
    }

    public void Update()
    {
        if (finishDay.finishDay)
        {
            text.text = "Press E to end day";
            endDayUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && inventoryCheck.getCheck() == false)
            {
                endDay();
            }
        }
    }

    private void endDay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}