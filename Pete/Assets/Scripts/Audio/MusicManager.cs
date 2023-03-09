using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private Sound mainMenuMusic;
    [SerializeField] private Sound finishMusic;
    [SerializeField] private Sound[] musicTracks;
    
    private AudioSource audioSource;
    private AudioClip lastPlayedSong;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private AudioClip GetRandomMusic()
    {   
        AudioClip audioClip;
        do
        {
            audioClip = musicTracks[Random.Range(0, musicTracks.Length)].clip;
        }while(audioClip == lastPlayedSong);
        
        Debug.Log(audioClip);
        return audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            SelectNewMusic();
        }
    }

    void SelectNewMusic()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            audioSource.clip = mainMenuMusic.clip;
        }
        else if(SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings-1)
        {
            audioSource.clip = GetRandomMusic();
        }
        else if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-1)
        {
            audioSource.clip = finishMusic.clip;
        }

        audioSource.Play();
        lastPlayedSong = audioSource.clip;
    }
}
