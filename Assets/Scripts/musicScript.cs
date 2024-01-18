using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class musicScript : MonoBehaviour
{
    AudioSource audiosource;
    double pauseClipTime = 0;
    [SerializeField]
    AudioClip[] clips;
    int currentClip =0;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = clips[currentClip];
        audiosource.Play();
    }
    private void Update()
    {
        PlayNextSongIfNeeded();
        
    }
    private void PlayNextSongIfNeeded()
    {
        if (audiosource.time >=clips[currentClip].length) {
            currentClip++;
            if(currentClip>clips.Length-1)
            {

                currentClip = 0;

            }
            audiosource.clip = clips[currentClip];
            audiosource.Play();
        }
    }
    public void OnPauseGame()
    {
        pauseClipTime = audiosource.time;
        audiosource.Play();

    }
    public void OnResumeGame()
    {
        audiosource.PlayScheduled(pauseClipTime);
        pauseClipTime = 0;



    }

    public void  PitchThis(float pitch)
    {
        audiosource.pitch = pitch;

    }
}
