using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] Slider musicSlider;

    private void Start()
    {
        // Inizializza gli slider con i valori da PlayerPrefs
        soundSlider.value = SaveGame.GetSoundVolume();
        musicSlider.value = SaveGame.GetMusicVolume();
    }

    public void PlayNewGame(int i)
    {
       
        AsyncOperation op = SceneManager.LoadSceneAsync(i);

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SaveSoundVolume()
    {
        float soundVolume = soundSlider.value;
        SaveGame.SaveSoundVolume(soundVolume);

        AudioManager.instance.SetSoundVolume(soundVolume);
    }

    public void SaveMusicVolume()
    {
        float musicVolume = musicSlider.value;
        SaveGame.SaveMusicVolume(musicVolume);

        AudioManager.instance.SetMusicVolume(musicVolume);
    }
}
