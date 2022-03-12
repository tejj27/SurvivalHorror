using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private WeaponManager weapon_manager;

    public float firerate = 15f;
    private float nextTimeToFire;

    private float damage = 20f;


    private Animator ZoomCameraAnim;

    private bool Zoomed;

    private Camera mainCam;

    private GameObject crossHair;

    private bool is_Aiming;






    // Start is called before the first frame update

    private void Awake() {
        weapon_manager = GetComponent<WeaponManager>();
        //finding child  transform in player
        ZoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();

        crossHair = GameObject.FindWithTag(Tags.CROSS_HAIR); // references to the object

        mainCam = Camera.main;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
        ZoomInAndOut();
    }

    void WeaponShoot()
    {
        //if we have a assualt rifle
        if(weapon_manager.GetCurrentSelectedWeapon().FireType == WeaponFireType.MULTIPLE)
        {
            //if we pressed and hold the left mouse button down 0
            if(Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f /firerate;
                weapon_manager.GetCurrentSelectedWeapon().ShootAnimation();

                BulletFired();
            }
        }
        else
        {
            // if we have regualr weapon

            if(Input.GetMouseButtonDown(0))
            {
                //Handle Axe
                if(weapon_manager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    weapon_manager.GetCurrentSelectedWeapon().ShootAnimation();
                }

                   //weapon Manager
                if(weapon_manager.GetCurrentSelectedWeapon().Bullettype == WeaponBullettype.BULLET)
                {
                weapon_manager.GetCurrentSelectedWeapon().ShootAnimation();
                BulletFired();

                }
                else
                {
                 // if we have an arrow aor sphere
                 if(is_Aiming)
                 {
                     //arrow and sphere
                 }
                }

            }
         

        }

    }


    void ZoomInAndOut()
    {
        if(weapon_manager.GetCurrentSelectedWeapon().weapon_Aim == WeaponAim.AIM)
        {
            if(Input.GetMouseButtonDown(1))
            {
                ZoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);

                crossHair.SetActive(false);
            }
            if(Input.GetMouseButtonUp(1))
            {
                ZoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);

                crossHair.SetActive(true);
            }
        }

        if(weapon_manager.GetCurrentSelectedWeapon().weapon_Aim == WeaponAim.SELF_AIM)
        {
            if(Input.GetMouseButtonDown(1))
            {
                weapon_manager.GetCurrentSelectedWeapon().AIM(true);
                is_Aiming = true;
            }
            if(Input.GetMouseButtonUp(1))
            {
                weapon_manager.GetCurrentSelectedWeapon().AIM(false);
                is_Aiming = false;
            }
        }

    }// zoom in and out 


    void BulletFired()
    {
        RaycastHit hit;

        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward, Color.red, 2f);
            print("We HIT :" + hit.transform.gameObject.name);
            
        }

    }// bullet fired
}
