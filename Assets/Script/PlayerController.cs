using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera cam;

    [SerializeField] Sprite rightSprite;
    [SerializeField] Sprite leftSprite;

    [SerializeField] Sprite speedBoostRightSprite;
    [SerializeField] Sprite speedBoostLeftSprite;

    private SpriteRenderer spriteRenderer;

    public int maxHealth = 10;

    [SerializeField] float currentSpeed = 5.0f;

    public int health {
        get { return currentHealth; }
    }

    int currentHealth;
    public Collider2D areaDiGioco;

    public bool isSpeedBoostActive;
    public bool isDead;

    private void Start()
    {
        Time.timeScale = 1;
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        isSpeedBoostActive = false;
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        InteractableObject interactableObject = other.GetComponent<InteractableObject>();
        if (interactableObject != null)
        {
            interactableObject.Interact();
        }
    }

    private void Update()
    {

        Vector2 input = Input.mousePosition;
        Vector3 worldInput = Camera.main.ScreenToWorldPoint(input);

        
        float newX = Mathf.Clamp(worldInput.x, areaDiGioco.bounds.center.x - areaDiGioco.bounds.extents.x, areaDiGioco.bounds.center.x + areaDiGioco.bounds.extents.x);
        float newY = Mathf.Clamp(worldInput.y, areaDiGioco.bounds.center.y - areaDiGioco.bounds.extents.y, areaDiGioco.bounds.center.y + areaDiGioco.bounds.extents.y);


        Vector3 newPosition = new Vector3(newX, newY, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPosition, currentSpeed * Time.deltaTime);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float horizontalDistance = mousePosition.x - transform.position.x;


        if (isSpeedBoostActive)
        {
            if (horizontalDistance > 0)
            {
                CambioSprite(speedBoostRightSprite);
            }
            else if (horizontalDistance < 0)
            {
                CambioSprite(speedBoostLeftSprite);
            }
        }
        else
        {
            //cambio di sprite normale quando lo SpeedBoost non è attivo
            if (horizontalDistance > 0)
            {
                CambioSprite(rightSprite);
            }
            else if (horizontalDistance < 0)
            {
                CambioSprite(leftSprite);
            }
        }




    }

    private void CambioSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    public void changeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        HealthBarScript.instance.SetValue(currentHealth / (float)maxHealth);

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Time.timeScale = 0;
            int finalScore = GameManager.instance.GetScore();

            GameManager.instance.gameOver();


            ScoreManager.instance.AddScore(finalScore);
            ScoreManager.instance.SaveScores(); 
            ScoreBoard.instance.UpdateHighScores(ScoreManager.instance.highScores); // Aggiorna la classifica nella UI
        }
    }

    public void ActivateSpeedBoost(float speedMultiplier, float duration)
    {
        if (!isSpeedBoostActive)
        {
            
            StartCoroutine(SpeedBoostCoroutine(speedMultiplier, duration));
        }
        
    }

    private IEnumerator SpeedBoostCoroutine(float speedMultiplier, float duration)
    {
        float originalSpeed = currentSpeed;
        currentSpeed *= speedMultiplier;
        isSpeedBoostActive = true;
      
        yield return new WaitForSeconds(duration);
        

        currentSpeed = originalSpeed;
        isSpeedBoostActive = false;
    }

 
}
