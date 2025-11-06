using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public ShopCounter finishDay;
    public GameObject endDayUI;
    private TMP_Text text;
    [SerializeField] WeekCounter weekCounter;
    [SerializeField] PlayerInventory inventoryCheck;
    [SerializeField] PotionStationData potionStationData;
    [SerializeField] PauseMenu pauseMenu;

    void Start()
    {
        text = endDayUI.GetComponent<TMP_Text>();
    }

    public void Update()
    {
        if (finishDay.finishDay)
        {
            text.text = "Press N to end day";
            endDayUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.N) && GetCheck())
            {
                endDay();
            }
        }
    }

    private bool GetCheck()
    {
        if (inventoryCheck.getCheck() || potionStationData.getCheck() || pauseMenu.getCheck())
            return false;
        return true;
    }
    private void endDay()
    {
        weekCounter.UpdateWeek();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}