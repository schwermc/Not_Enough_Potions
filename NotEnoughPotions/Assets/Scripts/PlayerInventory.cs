using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private CharacterController _controller;
    private bool active = false;
    public GameObject inventory;

    void Awake()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            updateUI();
        }
    }

    void updateUI()
    {
        if (!active)
        {
            active = true;
            Time.timeScale = 0f;
            inventory.SetActive(active);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            active = false;
            Time.timeScale = 1f;
            inventory.SetActive(active);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
