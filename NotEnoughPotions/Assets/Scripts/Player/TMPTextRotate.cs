using TMPro;
using UnityEngine;

public class TMPTextRotate : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    void Update()
    {
        text.transform.rotation = Quaternion.LookRotation(text.transform.position - Camera.main.transform.position);
    }
}
