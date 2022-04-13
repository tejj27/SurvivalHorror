using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    void OnEnable() {
        //Only specifyin the sceneName or sceneBuildIndex will load the scene with the single mode
        SceneManager.LoadScene("Scene_A", LoadSceneMode.Single);
        
    }
}
