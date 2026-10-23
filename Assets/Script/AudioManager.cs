using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; 
    private AudioSource musicSource, foodSource;
    [SerializeField] AudioClip soundTrack, foodClip;


    private void Awake()
    {
        instance = this;
        musicSource = gameObject.AddComponent<AudioSource>();
        foodSource = gameObject.AddComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        musicSource.loop = true;
        musicSource.volume = SaveGame.GetMusicVolume();
        musicSource.clip = soundTrack;
        musicSource.Play();

        foodSource.volume = SaveGame.GetSoundVolume();

    }

    public void PlayFoodSource()
    {
        foodSource.clip = foodClip;
        foodSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        SaveGame.SaveMusicVolume(volume);
    }

    public void SetSoundVolume(float volume)
    {
        foodSource.volume = volume;
        SaveGame.SaveSoundVolume(volume);
    }


}
