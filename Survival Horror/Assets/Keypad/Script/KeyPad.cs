using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPad : MonoBehaviour
{
    public static bool GameIsPaused=false;
    public GameObject KeyPadUI;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
        
    }
    public void Resume()
    {
        KeyPadUI.SetActive(false);
        Time.timeScale=1f;
        GameIsPaused=false;

    }
    void Pause()
    {
        
        KeyPadUI.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused=true;

    }
}

