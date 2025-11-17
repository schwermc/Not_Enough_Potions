using UnityEngine;
using TMPro;

public class EndText : MonoBehaviour
{
    public TextMeshProUGUI text;

    private EndCondition endCondition;
    private LoadScene loadScene;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        endCondition = new EndCondition();
        loadScene = new LoadScene();
        if (endCondition.GetGameWon())
            winGame();
        if (!endCondition.GetGameWon())
            loseGame();
    }

    public void retryGame()
    {
        loadScene.loadScene(SceneNames.gameScene);
    }

    void winGame()
    {
        text.text = "Game Won";
    }

    void loseGame()
    {
        text.text = "Lost!";
    }
}
