using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script stores the data which should persist between scenes
public class MainManager : MonoBehaviour
{    
    // values stored in this class member will be shared by all the instances of that class
    public static int playerScore;
    public static string playerName;

    // Statische Methode zum Setzen des Spielernamens
    public static void SetPlayerName(string name)
    {
        playerName = name;
    }

    public static void SetPlayerScore(int score)
    {
        playerScore = score;
    }

    // Statische Methode, um den aktuellen Score zu erhalten
    public static int GetPlayerScore()
    {
        return playerScore;
    }

    public static String GetPlayerName()
    {
        return MainManager.playerName;
    }

}
