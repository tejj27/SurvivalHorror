using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{

    private AudioSource AudioSource;

    [SerializeField]
    private AudioClip ScreamClip, DieClip;

    [SerializeField]
    private AudioClip[] Attack_clip; // because we have multiple attack clip 



    // Start is called before the first frame update
    void Awake()
    {
        AudioSource = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    public void Play_ScreamSound()
    {
        AudioSource.clip = ScreamClip;
        AudioSource.Play();
        
    }

    public void PlayAttackSound()
    {
        AudioSource.clip = Attack_clip[Random.Range(0, Attack_clip.Length)];
        AudioSource.Play();
    }

     public void PlayDeadSound()
    {
        AudioSource.clip = DieClip;
        AudioSource.Play();
    }
}
