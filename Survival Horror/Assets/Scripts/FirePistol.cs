using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{

    public GameObject TheGun;

    public GameObject MuzzleFlash;

    public AudioSource GunFire;

    public bool Isfiring = false;

    public float TargetDistance;

    public int DamageAmount = 5;
    void Update()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            if(Isfiring == false)
            {
                StartCoroutine(FiringPistol());
            }
        }
        
    }

    IEnumerator FiringPistol()
    {
 
        Isfiring = true;

        RaycastHit Shot;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            //information of Some Other Script
            Shot.transform.SendMessage("DamageZombie", DamageAmount, SendMessageOptions.DontRequireReceiver); // Varible we are sending

        }

        TheGun.GetComponent<Animation>().Play("PistolShot");
        MuzzleFlash.SetActive(true);

        MuzzleFlash.GetComponent<Animation>().Play("MuzzleAnim");
        
        GunFire.Play();
        yield return new WaitForSeconds(0.5f);

        Isfiring = false;


    }
}
