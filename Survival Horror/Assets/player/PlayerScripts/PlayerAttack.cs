using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public WeaponManager weapon_manager;

    public float firerate = 15f;
    private float nextTimeToFire;

    private float damage = 20f;


    // Start is called before the first frame update

    private void Awake() {
        weapon_manager = GetComponent<WeaponManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
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

                //bulletFired
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
                //BulletFired()

            }
            else
            {
                // if we have an error
            }

            
            }
         

        }

    }
}
