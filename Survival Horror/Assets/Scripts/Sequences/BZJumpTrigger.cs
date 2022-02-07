using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BZJumpTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource DoorBang;

    public AudioSource DoorJumpMusic;


    public GameObject TheZombie;

    public GameObject TheDoor;


    void OnTriggerEnter(Collider other) {

        GetComponent<BoxCollider>().enabled = false;
        TheDoor.GetComponent<Animation>().Play("JumpDoorAnim");

        DoorBang.Play();

        TheZombie.SetActive(true);
        StartCoroutine(PlayJumpMusic());


    }

    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(0.4f);

        DoorJumpMusic.Play();
    }
}
