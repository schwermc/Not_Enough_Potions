using UnityEngine;
using UnityEngine.UI;

public class MakePotion : MonoBehaviour
{

    public InventoryData inventory;

    private bool check;
    private PotionItem buttonText;
    private Button button;

    [SerializeField] private PotionData data;
    [SerializeField] PotionStationData stationData;

    void Start()
    {
        buttonText = GetComponent<PotionItem>();
        button = GetComponent<Button>();
        for (int i = 0; i < stationData.Container.Count; i++)
        {
            if (buttonText.getName().text == stationData.Container[i].name)
            {
                data = stationData.Container[i];
            }
        }
    }

    void Update()
    {
        check = checkList(data);
        if (check)
        {
            button.interactable = true;
        }

        if (!check)
        {
            button.interactable = false;
        }
    }

    public void potionButton()
    {
        if (data != null)
        {
            addToInventory(data, 1);
        }
    }

    bool checkList(PotionData potion)
    {
        bool notInList = false;
        int listAmount = 0;

        if (inventory.Container.Count < 1)
        {
            return false;
        }

        for (int i = 0; i < potion.Ingredients.Count; i++)
        {
            for (int j = 0; j < inventory.Container.Count; j++)
            {
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
                notInList = true;
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