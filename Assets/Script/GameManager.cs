using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab;
    [SerializeField] GameObject specialFoodPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject powerupPrefab;
    [SerializeField] GameObject enemyPrefab;
    public static GameManager instance;
    [SerializeField] Vector2 xRange;
    [SerializeField] Vector2 yRange;

    [SerializeField] Vector2 xRangeEnemy;
    [SerializeField] Vector2 yRangeEnemy;

    public GameObject gameOverUI;

    [SerializeField] Text scoreText;

    private int score = 0;  // Variabile per il punteggio
                            
   

    private void Awake()
    {
        instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
       

        for (int i=0; i<500; i++) {
            SpawnFood();
        }

        for (int i = 0; i < 20; i++)
        {
            SpawnSpecialFood();
        }

        for(int i=0; i<10; i++)
         {
           SpawnObstacle();
         }

        for (int i=0; i<10; i++)
        {
            SpawnPowerUp();
        }

        for(int i=0; i<8; i++)
        {
            SpawnEnemy();
        }

        score = 0;
    }


    public void SpawnFood()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 1);
        GameObject _food = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);   
    }

    public void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 1);
        GameObject _obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }

    public void SpawnSpecialFood()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 1);
        GameObject _specialfood = Instantiate(specialFoodPrefab, spawnPosition, Quaternion.identity);

    }

    public void SpawnPowerUp()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 1);
        GameObject _powerup = Instantiate(powerupPrefab, spawnPosition, Quaternion.identity);

    }

    public void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(xRangeEnemy.x, xRangeEnemy.y), Random.Range(yRangeEnemy.x, yRangeEnemy.y), 1);
        GameObject _enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

    }


    // Metodo per aumentare il punteggio
    public void IncreaseScore(int amount)
    {
        Debug.Log("amount:" + amount);
        score += amount;
        scoreText.text = "Score: " + score.ToString();
        AudioManager.instance.PlayFoodSource();
    }

    // Metodo per ottenere il punteggio attuale
    public int GetScore()
    {
        return score;
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
