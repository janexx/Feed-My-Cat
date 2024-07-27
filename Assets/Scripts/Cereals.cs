using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cereals : MonoBehaviour
{
    public int myScorePoint = 10;
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
            Debug.Log("Foot collected");
            //StartCoroutine("DestroyFoodOnClipend");
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

    // Wait until the AUdio clip ends end then destroy the food object
    /*IEnumerator DestroyFoodOnClipend()
    {
        yield return new WaitForSeconds(foodAudio.clip.length);
        Destroy(gameObject);
    } */

    

    
}


