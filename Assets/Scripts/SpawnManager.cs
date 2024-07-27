using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemie;
    public GameObject[] foodItems;

    private float zEnemySpawn = 10.0f;
    private float xSpawnRange = 7.5f;
    private float ySpawnPos = 0.5f;
    private float zFoodRange = 9.0f;

    private float enemySpawnTime = 6.0f;
    private float foodSpawnTime = 3.0f;
    private float newEnemySpawnTime;

    public GameObject gameManager;
    private int level;
    private int score;

    // Start is called before the first frame update
    void Start()
    {        
        level = gameManager.GetComponent<GameManager>().currentLevel;

        Repeat();
    }

    private void Repeat()
    {
        InvokeRepeating("SpawnEnemy", 1, enemySpawnTime);
        InvokeRepeating("SpawnFood", 0, foodSpawnTime);
    }
    private void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        Vector3 spawnPosition = new Vector3(randomX, ySpawnPos, zEnemySpawn);
        Instantiate(enemie, spawnPosition, enemie.transform.rotation);
    }

    private void SpawnFood()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, foodItems.Length);
        Vector3 spawnPosition = new Vector3(randomX, ySpawnPos, zFoodRange);

        Instantiate(foodItems[randomIndex], spawnPosition, foodItems[randomIndex].transform.rotation);
    }

    public void FastenEnemySpawnTime( float timeToAdd)
    {
        CancelInvoke("Repeat");
        enemySpawnTime -= timeToAdd;
        Repeat();
        Debug.Log("Enemy Spawn time: " + enemySpawnTime);
    }
}
