using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set; } //Instance des Audiomanagers

    //Array for all the SoundEffects
    public Sound[] sounds;

    //Function to Instantiate the SoundEffects
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound '" + name + "' was not found!");
            return;
        }
        s.source.Play();
    }    

    private void Awake() 
    {
        //Instance check
        if(Instance == null)
        {
            Instance = this;
        }    
        else
        {
            Destroy(gameObject);
        }

        //Getting SoundEffects
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
}
