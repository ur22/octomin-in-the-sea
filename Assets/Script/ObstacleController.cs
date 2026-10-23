using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] Sprite rightSprite;
    [SerializeField] Sprite leftSprite;
    private SpriteRenderer spriteRenderer;

    public float velocita = 0.5f;
    public float intervalloCambioDirezione = 2.0f;

    private Rigidbody2D rb;
    private float timerCambioDirezione;
    private Vector2 direzione = Vector2.right; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timerCambioDirezione = intervalloCambioDirezione;
    }

    void Update()
    {
        timerCambioDirezione -= Time.deltaTime;
        if (timerCambioDirezione <= 0)
        {
            CambiaDirezione();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = direzione * velocita;
    }

    void CambiaDirezione()
    {
        
        if (direzione == Vector2.right)
        {
            direzione = Vector2.left; 
            CambioSprite(leftSprite);
        }
        else
        {
            direzione = Vector2.right; 
            CambioSprite(rightSprite);
        }
        timerCambioDirezione = intervalloCambioDirezione;
    }


    private void CambioSprite(Sprite newSprite)
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        spriteRenderer.sprite = newSprite;
    }


    void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.CompareTag("Player"))
            {

              
                PlayerController playerController = other.GetComponent<PlayerController>();

                if (playerController != null)
                {
                    playerController.changeHealth(1);
                }

                
                Destroy(gameObject);
            }
        }
    
}
