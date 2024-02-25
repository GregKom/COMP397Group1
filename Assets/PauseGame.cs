using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public int isGamePaused = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isGamePaused *= -1;
        }

        if (isGamePaused == -1) Time.timeScale = 1;
        if (isGamePaused == 1) Time.timeScale = 0;
    }
}
