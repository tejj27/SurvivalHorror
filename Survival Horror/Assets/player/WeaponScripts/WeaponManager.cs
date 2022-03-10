using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponHandler[] Weapons;

    private int Current_Weapon_Index;

    void Start()
    {
        Current_Weapon_Index = 0;
        Weapons[Current_Weapon_Index].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Turn_On_selectedWeapon(0);

        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Turn_On_selectedWeapon(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Turn_On_selectedWeapon(2);
            
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            Turn_On_selectedWeapon(3);
            
        }
    }


    void Turn_On_selectedWeapon(int WeaponIndex)
    {
        // Turn Off the Current wepaon Index
        Weapons[Current_Weapon_Index].gameObject.SetActive(false);

        //Turn On the Selected Weapon Index 
        Weapons[WeaponIndex].gameObject.SetActive(true);

        // Set Integer to Current Index
        Current_Weapon_Index = WeaponIndex;
    }

    public WeaponHandler GetCurrentSelectedWeapon()
    {
        // we Have Aim FireType BulletType WE can Get those Info From this Function

        return Weapons[Current_Weapon_Index];
    }
}
