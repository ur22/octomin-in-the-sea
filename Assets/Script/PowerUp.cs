using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : InteractableObject
{
    public float speedMultiplier = 3.0f; 
    public float duration = 10.0f;

    private PlayerController player;

  

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public override void Interact()
    {
        
        if (player != null && !player.isSpeedBoostActive)
        {
            
            player.ActivateSpeedBoost(speedMultiplier, duration);
            GameManager.instance.SpawnPowerUp();
            Destroy(gameObject);
        }
   
    }

}