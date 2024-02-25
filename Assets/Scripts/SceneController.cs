using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject optionsCanvas;
    public GameObject mainMenuCanvas;

    public void LoadScene(string sceneName)
    {
        Debug.Log("Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
        if(sceneName == "GameScene")
        {
            Resume();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuCanvas.SetActive(false);
    }

    public void Options(){
        optionsCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
