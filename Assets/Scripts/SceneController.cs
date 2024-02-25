using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject pauseMenuCanvas;

    public void LoadScene(string sceneName)
    {
        Debug.Log("Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
        if(sceneName == "GameScene"){
            Resume();
        }
    }

    public void Resume(){
        Time.timeScale = 1f;
        pauseMenuCanvas.SetActive(false);
    }
}
