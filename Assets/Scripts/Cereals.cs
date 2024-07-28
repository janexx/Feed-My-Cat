using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cereals : MonoBehaviour
{
    public int myScorePoint = 1;
    public bool foodIsCollected = false;
    private GameManager gamemanager;

    //public static event Action<int> OnFoodCollected;

    private void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }


    // When food collides with player (lands in bowl) food gets destroyed
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foodIsCollected = true;
            Destroy(gameObject);
            gamemanager.UpdateScore(myScorePoint);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foodIsCollected = false;
        }
    }
    
}


