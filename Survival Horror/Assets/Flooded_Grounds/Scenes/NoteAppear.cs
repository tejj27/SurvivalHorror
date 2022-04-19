using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NoteAppear : MonoBehaviour
{
    public GameObject Image;
    public GameObject clue;

    bool IsInteracting;

    public GameObject AnimeObject;
    public bool Actions=false;

    // Start is called before the first frame update
    void Start()
    {
        Image.SetActive(false);
        clue.SetActive(false);
        
    }
    void OnTriggerEnter(Collider collision) {
        IsInteracting = true;
        if(collision.gameObject.tag=="Player")
        {
           if(IsInteracting == true)
           {
                InstructionToggle(true);
           }

        
        }

       
    }
    void OnTriggerExit(Collider collision)
    {
        InstructionToggle(false);
    }
    // Update is called once per frame
     void InstructionToggle(bool Active)
     {
        clue.SetActive(Active);
        Image.SetActive(Active);
        Actions = Active;
     }
   
        
}
    


