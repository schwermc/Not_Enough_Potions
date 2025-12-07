using UnityEngine;

public class Menu : MonoBehaviour
{
    private LoadScene loadScene;

    void Start()
    {
        loadScene = new LoadScene();
    }

    public void GameButton()
    {
        loadScene.loadScene(SceneNames.gameScene);
    }

    public void MenuButton()
    {
        loadScene.loadScene(SceneNames.menuScene);
    }
}
