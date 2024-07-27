using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody playerRB;
    private GameObject enemy;
    private GameObject cereal;
    private AudioSource playerAudio;
    public List<AudioClip> audioclips;
    private GameManager gameManager;

    private float xBound = 8.0f;
    private float horizontalInput;
    public float speed = 25f;
    public float currentSpeed;
    public bool foodIsCollected = false;
    public bool gameIsOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        KeepInBounds();
    }

    private void MovePlayer()
    {
        //Store user input as a movement vector
        Vector3 horizontalInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        // Player can move left and right
        //horizontalInput = Input.GetAxis("Horizontal");
        playerRB.MovePosition(transform.position + horizontalInput  * Time.deltaTime * speed);
        // Give the animator the current speed to change animation states
        currentSpeed = playerRB.velocity.magnitude;        
    }

    private void KeepInBounds()
    {
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }


    // On collision with the enemy a sound plays and the enemy stops
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.gameObject;
            playerAudio.clip = audioclips[1]; // play negative sound
            playerAudio.Play();
            gameManager.SetCatText("Ugh!");
            gameIsOver = true;
            StartCoroutine("DestroyEnemyOnClipend");
        }

        // Detect Collission with food (for Gamemanager)
        if (collision.gameObject.tag == "Food")
        {
            cereal = collision.gameObject;
            foodIsCollected =true;
            playerAudio.clip = audioclips[0]; // play positive sound
            playerAudio.Play();
            StartCoroutine("DestroyFoodOnClipend");
            gameManager.SetCatText("Yummi!");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        foodIsCollected = false;
    }


    // Wait until the AUdio clip ends end then destroy the food object
    IEnumerator DestroyEnemyOnClipend()
    {
        yield return new WaitForSeconds(playerAudio.clip.length);
        Destroy(enemy);
    }

    IEnumerator DestroyFoodOnClipend()
    {
        yield return new WaitForSeconds(playerAudio.clip.length);
        Destroy(cereal);
    }

    public bool foodJustCollected()
    {
        return foodIsCollected;
    }

   

}
