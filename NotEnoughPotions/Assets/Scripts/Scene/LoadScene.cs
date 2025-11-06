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
        bool check = false;
        int checks = 0;
        if (inventoryCheck.getCheck() == false)
            checks++;
        if (potionStationData.getCheck() == false)
            checks++;
        if (pauseMenu.getCheck() == false)
            checks++;
        if (checks == 3)
            check = true;
        return check;
    }
    private void endDay()
    {
        weekCounter.UpdateWeek();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}