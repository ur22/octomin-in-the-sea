using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveGame 
{
    public static void SaveMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MUSIC", volume);
        PlayerPrefs.Save();
    }

    public static void SaveSoundVolume(float volume)
    {
        PlayerPrefs.SetFloat("SOUND", volume);
        PlayerPrefs.Save();
    }

    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat("MUSIC");
    }

    public static float GetSoundVolume()
    {
        return PlayerPrefs.GetFloat("SOUND");
    }
}
