using TMPro;
using UnityEngine;

public class CustomerList : MonoBehaviour
{
    private int costOfCart = 0;

    [SerializeField] CustomerCart cart;
    [SerializeField] TMP_Text text;

    void Start()
    {
        for (int i = 0; i < cart.Container.Count; i++)
        {
            text.text += cart.Container[i].getItem().name + ": " + cart.Container[i].getAmount();
            costOfCart += (int) cart.Container[i].getItem().sellAmount * cart.Container[i].getAmount();
            if (i < cart.Container.Count)
                text.text += "\n";
        }
        text.text += costOfCart.ToString() + " G";
    }

    void Update()
    {
        text.transform.rotation = Quaternion.LookRotation(text.transform.position - Camera.main.transform.position);
    }

}