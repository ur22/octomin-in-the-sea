using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreEntry
{
    public int score;
}

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; 

    public List<ScoreEntry> highScores = new List<ScoreEntry>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); // Se esiste già un'istanza, la sidtrugge
        }
    }

    public void AddScore(int score)
    {
        ScoreEntry newEntry = new ScoreEntry { score = score };
        highScores.Add(newEntry);
        highScores.Sort((a, b) => b.score.CompareTo(a.score));
        if (highScores.Count > 5)
        {
            highScores.RemoveAt(highScores.Count - 1); 
        }
    }

    public void SaveScores()
    {
        string scoreData = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("HighScores", scoreData);
        PlayerPrefs.Save();
    }

    public void LoadScores()
    {
        if (PlayerPrefs.HasKey("HighScores"))
        {
            string scoreData = PlayerPrefs.GetString("HighScores");
            ScoreManager loadedScores = JsonUtility.FromJson<ScoreManager>(scoreData);
            highScores = loadedScores.highScores;
        }
    }

}


