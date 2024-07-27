using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float enemySpeed = 2.0f;
    private Rigidbody enemyRB;
    private int level;
    float speedBoost;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        level = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().currentLevel;
    }

    void FixedUpdate()
    {
        speedBoost = level / 5 +1;
        enemyRB.AddForce(Vector3.forward * -enemySpeed * speedBoost);
    }

    public void StopEnemy()
    {
        enemySpeed = 0f;
        enemyRB.Sleep();
    }

}
