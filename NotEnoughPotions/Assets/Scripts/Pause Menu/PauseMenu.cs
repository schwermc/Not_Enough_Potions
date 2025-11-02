using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] PotionStationData potionStationData;
    private bool isGamePause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Delete))
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (!isGamePause && playerInventory.getCheck())
        {
            if (playerInventory.getCheck())
                playerInventory.updateUI();
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }

        if (!isGamePause && potionStationData.getCheck())
        {
            if (potionStationData.getCheck())
                potionStationData.updateUI();
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }

        if (!isGamePause && !playerInventory.getCheck())
        {
            Cursor.lockState = CursorLockMode.None;
            isGamePause = true;
            pauseMenu.SetActive(true);
            playerInventory.enabled = false;
            Time.timeScale = 0f;
            return;
        }

        if (isGamePause)
        {
            Cursor.lockState = CursorLockMode.Locked;
            isGamePause = false;
            pauseMenu.SetActive(false);
            playerInventory.enabled = true;            
            Time.timeScale = 1f;
            return;
        }
    }
}
