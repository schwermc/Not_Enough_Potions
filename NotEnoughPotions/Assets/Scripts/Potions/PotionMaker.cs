using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PotionMaker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InventoryData inventory;

    private bool check;
    private ItemButtonUI buttonText;
    private Button button;
    private TMP_Text hoverText;

    [SerializeField] PotionData potionData;
    [SerializeField] PotionStationData stationData;
    [SerializeField] GameObject hoverPopup;

    void Awake()
    {
        hoverPopup = GameObject.FindGameObjectWithTag("HoverPopup");
    }

    void Start()
    {
        hoverPopup.SetActive(false);

        buttonText = GetComponent<ItemButtonUI>();
        button = GetComponent<Button>();
        for (int i = 0; i < stationData.Container.Count; i++)
        {
            if (buttonText.getName().text == stationData.Container[i].name)
            {
                potionData = stationData.Container[i];
            }
        }

        hoverText = hoverPopup.GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        check = checkList(potionData);
        if (check)
        {
            button.interactable = true;
        }

        if (!check)
        {
            button.interactable = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverPopup.SetActive(true);
        hoverText.text = potionData.ListIngredients();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverPopup.SetActive(false);
    }

    public void potionButton()
    {
        if (potionData != null)
        {
            addToInventory(potionData, 1);
        }
    }

    bool checkList(PotionData potion)
    {
        bool notInList = true;
        int listAmount = 0;

        if (inventory.Container.Count < 1)
        {
            return false;
        }

        for (int i = 0; i < potion.Ingredients.Count; i++)
        {
            for (int j = 0; j < inventory.Container.Count; j++)
            {
                notInList = true;
                if (potion.Ingredients[i].item == inventory.Container[j].getItem())
                {
                    if (potion.Ingredients[i].amount > inventory.Container[j].getAmount())
                    {
                        return false;
                    }
                    notInList = false;
                    listAmount++;
                    continue;
                }
            }
        }

        if (notInList && listAmount != potion.Ingredients.Count)
        {
            return false;
        }
        return true;
    }

    public void addToInventory(PotionData potion, int _amount)
    {
        if (check)
        {
            for (int i = 0; i < potion.Ingredients.Count; i++)
            {
                inventory.SubItem(potion.Ingredients[i].item, potion.Ingredients[i].amount);
            }
            inventory.AddItem(potion, _amount);
        }
    }

    public bool getCheck()
    {
        return check;
    }
}