using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            endDay();
        }
    }

    private void endDay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}