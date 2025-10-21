using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public PlayerInventory playerInventory;
    private bool isGamePause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (!isGamePause)
        {
            isGamePause = true;
            pauseMenu.SetActive(true);
            playerInventory.enabled = false;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            return;
        }

        if (isGamePause)
        {
            isGamePause = false;
            pauseMenu.SetActive(false);
            playerInventory.enabled = true;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
    }
}
