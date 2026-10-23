using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text[] scoreTextElements; 

    public static ScoreBoard instance;

    private void Awake()
    {
        instance = this; 
    }

   
    public void UpdateHighScores(List<ScoreEntry> highScores)
    {
        for (int i = 0; i < scoreTextElements.Length; i++)
        {
            if (i < highScores.Count)
            {
                scoreTextElements[i].text = (i + 1).ToString() + ". "+"\t\t\t\t\t\t\t"+highScores[i].score.ToString();
            }
            else
            {
                scoreTextElements[i].text = "";
            }
        }
    }
}

