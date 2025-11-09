public class EndCondition
{
    private static bool gameWon = false;
    private string sceneName = SceneNames.endScene;

    public string GetSceneName() { return sceneName; }
    public void SetGameWon(bool condition) { gameWon = condition; }
    public bool GetGameWon() { return gameWon; }
}
