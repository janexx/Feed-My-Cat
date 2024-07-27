using UnityEngine;

public class CerealsSpawnManager : MonoBehaviour
{
    public GameObject enemie;
    public GameObject[] foodItems;
    public GameObject bowl;

    private float zEnemySpawn;
    private float xSpawnRange = 8.0f;
    private float ySpawnPos;
    private float zFoodRange;
    private Quaternion objectRotation;
    private float randomAngle;

    private float enemySpawnTime = 6.0f;
    private float foodSpawnTime = 3.0f;
    private float newEnemySpawnTime;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        // Set y and z spawn position dependent from (fix) bowl position
        zEnemySpawn = bowl.transform.position.z;
        ySpawnPos = bowl.transform.position.y + 18.0f;
        zFoodRange = bowl.transform.position.z;
        randomAngle = Random.Range(0, 360);
        objectRotation = Quaternion.Euler(randomAngle, randomAngle, randomAngle);
    }

    public void Spawn()
    {
        InvokeRepeating("SpawnEnemy", 1, enemySpawnTime);
        InvokeRepeating("SpawnFood", 0, foodSpawnTime);
    }
    private void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        Vector3 spawnPosition = new Vector3(randomX, ySpawnPos, zEnemySpawn);
        Instantiate(enemie, spawnPosition, objectRotation);
        
    }

    private void SpawnFood()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, foodItems.Length);
        Vector3 spawnPosition = new Vector3(randomX, ySpawnPos, zFoodRange);

        Instantiate(foodItems[randomIndex], spawnPosition, objectRotation);
    }

    public void FastenEnemySpawnTime( float timeToAdd)
    {
        CancelInvoke("Spawn");
        enemySpawnTime -= timeToAdd;
        Spawn();
        Debug.Log("Enemy Spawn time: " + enemySpawnTime);
    }

    public void StopSpawning()
    {
        CancelInvoke("Spawn");
        Debug.Log("Spawning stopped");
    }

    public void DestroyCereals()
    {
        foreach (var item in foodItems)
        {
            item.gameObject.SetActive(false);
        }
    }
}
