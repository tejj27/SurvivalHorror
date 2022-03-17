using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();

    }

    private void Start() {
    
    }

    public void Walk(bool Walk)
    {
        anim.SetBool(AnimationTags.WALK_PARAMETER, Walk);
    }

    public void Run(bool run)
    {
        anim.SetBool(AnimationTags.RUN_PARAMETER, run);
    }

    public void Attack()
    {
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER);
    }
    public void Dead()
    {
        anim.SetTrigger("Dead");
    }
}
