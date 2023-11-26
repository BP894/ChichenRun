using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip menuSound;
    public AudioClip jumpSound;
    private new AudioSource audio;
    
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayOnMenuSound()
    {
        audio.PlayOneShot(menuSound);
    }
    public void PlayOnJumpSound()
    {
        audio.PlayOneShot(jumpSound);
    }
}
