using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject Instruction;

    bool IsInteracting;

    public GameObject AnimeObject;
    public bool Action=false;

    // Start is called before the first frame update
    void Start()
    {
        Instruction.SetActive(false);
        
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
    void OnTriggerExit(Collider collision) {
        InstructionToggle(false);
    }
    // Update is called once per frame
     void InstructionToggle(bool Active)
     {
         Instruction.SetActive(Active);
         Action = Active;
     }
        
    private void Update() {
        if(IsInteracting == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Keypad");
                KeyPad.instance.Pausekeypad();
                InstructionToggle(false);
                GameObject Canvas = GameObject.Find("CrossHair");
                Canvas.SetActive(false);
                Cursor.lockState=CursorLockMode.None;

            }
        }
        
    }
}
