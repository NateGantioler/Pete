using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set; } //Instance des Audiomanagers

    //Variables for all of the SoundEffect Prefabs
    public GameObject S_Jump, S_FlyOrb, S_HitMarker, S_Hit;

    //Function to Instantiate the SoundEffects
    public void PlaySound(GameObject soundEffect)
    {
        GameObject _SoundObject = Instantiate(soundEffect, this.transform);
        StartCoroutine(DestroySound(_SoundObject));
    }    

    //Function to Destroy the SoundEffects after a few Seconds1
    private IEnumerator DestroySound(GameObject soundObject)
    {
        yield return new WaitForSeconds(3f);
        Destroy(soundObject);
    }

    //Instance check
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }    
        else
        {
            Destroy(gameObject);
        }
    }
}
