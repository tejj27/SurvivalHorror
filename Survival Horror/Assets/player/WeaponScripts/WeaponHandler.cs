using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponAim
{
    NONE,
    SELF_AIM,
    AIM
}

public enum WeaponFireType
{
    SINGLE,
    MULTIPLE
}


public enum WeaponBullettype
{
    BULLET,
    NONE
}


public class WeaponHandler : MonoBehaviour
{
    private Animator Anim;

    public WeaponAim weapon_Aim;
 
    [SerializeField]
    private GameObject MuzzleFlash;

    public AudioSource ShootSound, reload_sound;

    public WeaponFireType FireType;

    public WeaponBullettype Bullettype;

    public GameObject attack_point;

    private void Awake() {
        Anim = GetComponent<Animator>();


    }

    public void ShootAnimation()
    {
        Anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }


    public void AIM(bool CanAim)
    {
        Anim.SetBool(AnimationTags.AIM_PARAMETER, CanAim);

    }


    void Turn_On_MuzzleFlash()
    {
        MuzzleFlash.SetActive(true);

    }

    void Turn_Off_MuzzleFlash()
    {
        MuzzleFlash.SetActive(false);
        
    }

    void Play_ShootSOund()
    {
        ShootSound.Play();
    }

    void Play_ReloadSound()
    {
        reload_sound.Play();
    }

    void Turn_on_AttackPoint()
    {
        attack_point.SetActive(true);
    }

    void Turn_off_AttackPoint()
    {
        if(attack_point.activeInHierarchy)
        {
            attack_point.SetActive(false);
        }
    }
}//class






















