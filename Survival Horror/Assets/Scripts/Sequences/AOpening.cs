using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AOpening : MonoBehaviour
{
    public GameObject ThePlayer;

    public GameObject FadeScreenIn;

    public GameObject TextBox;

    void Start()
    {
        ThePlayer.GetComponent<PlayerMovement>().enabled = false;

        StartCoroutine(ScenePlayer());
        
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        FadeScreenIn.SetActive(false);

        TextBox.GetComponent<Text>().text = "I need to Get Out Of Here";

        yield return new WaitForSeconds(2);

        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<PlayerMovement>().enabled = true;


    }

}
