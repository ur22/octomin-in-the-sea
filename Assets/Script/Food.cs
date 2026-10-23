using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : InteractableObject
{
    public FoodType foodType;

    public int scoreValue = 30;
    public int specialScoreValue = 100;
    

    public enum FoodType
    {
        Regular, // Cibo normale
        Special // Cibo speciale
    }

    public override void Interact()
    {
         
         GameManager.instance.SpawnFood();
         Destroy(gameObject); 

       int score;
        if (foodType == FoodType.Special)
        {
            score = specialScoreValue;
        }
        else
        {
            score = scoreValue;
        }
       
        GameManager.instance.IncreaseScore(score);
        GameManager.instance.SpawnFood();
        Destroy(gameObject);
    }
}
