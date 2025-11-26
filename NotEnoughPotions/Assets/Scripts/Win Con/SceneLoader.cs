using UnityEngine;
using TMPro;

using System;

public class SceneLoader : MonoBehaviour
{
    public ShopCounter finishDay;
    public GameObject endDayUI;

    private TMP_Text text;
    private EndCondition endCondition;
    private LoadScene loadScene;

    [Header("SerializeField")]
    [SerializeField] string sceneName;
    [SerializeField] WeekCounter weekCounter;
    [SerializeField] PlayerInventory inventoryCheck;
    [SerializeField] PotionStationData potionStationData;
    [SerializeField] PauseMenu pauseMenu;
    [SerializeField] GardenMenu gardenMenu;
    [SerializeField] Money money;
    [SerializeField] int amountOfWeeks = 1;

    void Start()
    {
        text = endDayUI.GetComponent<TMP_Text>();
        endCondition = new EndCondition();
        loadScene = new LoadScene();
    }

    public void Update()
    {
        if (finishDay.finishDay)
        {
            text.text = "Press N to end day";
            endDayUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.N) && GetCheck())
            {
                endDay(sceneName);
            }
        }
    }

    public void endDay(String name)
    {
        if (weekCounter.GetCurrentDay() <= 7)
            weekCounter.UpdateWeek();

        if (weekCounter.GetWeekCounter() > amountOfWeeks)
        {
            name = endCondition.GetSceneName();
            endCondition.SetGameWon(money.HaveEnoughGold());
        }

        loadScene.loadScene(name);
    }

    private bool GetCheck()
    {
        if (inventoryCheck.getCheck() || potionStationData.getCheck() || pauseMenu.getCheck() || gardenMenu.getCheck())
            return false;
        return true;
    }
}