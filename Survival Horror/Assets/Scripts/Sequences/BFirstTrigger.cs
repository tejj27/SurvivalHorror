using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BFirstTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ThePlayer;

    public GameObject TextBox;

    public GameObject TheMarker;

    void OnTriggerEnter(Collider other) {

        
    
        ThePlayer.GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(ScenePlayer());
        
    }

    IEnumerator ScenePlayer()
    {

        TextBox.GetComponent<Text>().text = "Looks Like A weapon On that Table";
        yield return new WaitForSecondsRealtime(2.5f);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<PlayerMovement>().enabled = true;

        TheMarker.SetActive(true);
    }
   
}
