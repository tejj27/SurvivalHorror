using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPad : MonoBehaviour
{
    public bool GameIsPaused = false;

    public static KeyPad instance;
    public GameObject KeyPadUI;


    private void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.E))
        // {
        //     if(GameIsPaused == false)
        //     {
        //         Pausekeypad();
        //     }
        //     else if(GameIsPaused == true)
        //     {
        //         ResumeKeypad();
        //     }

        // }
        
    }
    
    public void ResumeKeypad()
    {
       
        KeyPadUI.SetActive(false);
        Time.timeScale=1f;
        GameIsPaused=false;
        MouseLookAround.instance.CanMove = true;
        Cursor.lockState = CursorLockMode.None;

    }
    public void Pausekeypad()
    {
        KeyPadUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused=true;
        MouseLookAround.instance.CanMove = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}

