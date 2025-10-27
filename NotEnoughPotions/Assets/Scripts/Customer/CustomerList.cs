using TMPro;
using UnityEngine;

public class CustomerList : MonoBehaviour
{
    [SerializeField] CustomerCart cart;
    [SerializeField] TMP_Text text;

    void Start()
    {
        for (int i = 0; i < cart.Container.Count; i++)
        {
            text.text += cart.Container[i].getItem().name + ": " + cart.Container[i].getAmount();
            if (i < cart.Container.Count - 1)
                text.text += "\n";
        }
    }

    void Update()
    {
        text.transform.rotation = Quaternion.LookRotation(text.transform.position - Camera.main.transform.position);
    }

}