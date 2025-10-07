using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void endDay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}