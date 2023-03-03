using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    [SerializeField] private Slider volumeSlider;
    private AudioManager audioManager;

    void Awake()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }

    }

    private void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void ChangeVolume() 
    {
        AudioManager.Instance.ChangeGenralVolume(volumeSlider.value);
    }
}
