using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPistol : MonoBehaviour
{
    
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject FakePistol;

    public GameObject RealPistol ;

    public GameObject GuideArrow;
    
    public GameObject ExtraCross;
    public GameObject ThejumpTrigger;


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

            ActionText.GetComponent<Text>().text = "PickUpPistol ";

            ExtraCross.SetActive(true);

        }
        if(Input.GetButtonDown("Action"))
        {
            if(TheDistance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                FakePistol.SetActive(false);
                RealPistol.SetActive(true);
                ExtraCross.SetActive(false);
                GuideArrow.SetActive(false);
                ThejumpTrigger.SetActive(true);
        
            }
        }
    }

    void OnMouseExit() {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
        
        
    }
}
