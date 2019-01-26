using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioSequencing : MonoBehaviour
{
    public AudioSource backgroundMusicIntro;
    public AudioSource backgroundMusicLoop;

    private bool startedLoop;
    
    void FixedUpdate() 
    {
      if(!backgroundMusicIntro.isPlaying && !startedLoop) 
        {
            backgroundMusicLoop.Play();
            startedLoop = true;
        }
    }
}
