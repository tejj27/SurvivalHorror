using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxeWushSound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioSource audio_source;

    [SerializeField]
    private AudioClip[] Woosh_sound;



    void playWooshSound()
    {
        audio_source.clip = Woosh_sound[Random.Range(0, Woosh_sound.Length)];
        audio_source.Play();
    }
}
