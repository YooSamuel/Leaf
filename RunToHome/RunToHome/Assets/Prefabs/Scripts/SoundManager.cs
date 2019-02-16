using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

    public AudioMixer audioMixer;
    public AudioSource bgmSource;
    public AudioSource sfxSource;


    void Start () 
    {
        bgmSource.Play();
	}
	

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("master", volume);
    }
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("bgm", volume);
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("sfx", volume);
    }
}
