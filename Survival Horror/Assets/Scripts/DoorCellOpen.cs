using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCellOpen : MonoBehaviour
{
    
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject TheDoor;

    public AudioSource CreakSound;

    public GameObject ExtraCross;


    // Update is called once per frame
    void Update()
    {
        TheDistance = LayerCasting.DistancefromTarget;

    

    }

    void OnMouseOver() {
        if(TheDistance <= 3)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ExtraCross.SetActive(true);

        }
        if(Input.GetButtonDown("Action"))
        {
            if(TheDistance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                TheDoor.GetComponent<Animation>().Play("FirstDoorOpenAnim");
                CreakSound.Play();
            }
        }
    }

    void OnMouseExit() {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
        
    }
}
