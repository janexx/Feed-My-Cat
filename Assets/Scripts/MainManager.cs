using System;
using UnityEngine;
using System.IO;

// This script stores the data which should persist between scenes
public class MainManager : MonoBehaviour
{
    // values stored in this class member will be shared by all the instances of that class
    public static int playerScore;
    public static int highscore;
    public static string playerName;
    public static string highscorePlayer;

    private void Awake()
    {
        LoadHighscore();
    }

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

    public static int GetHighscore()
    {
        return highscore;
    }


    // Save Highscore data to file
    [System.Serializable]
    class SaveData
    {
        public string highscorePlayer;
        public int highscore;
    }

    public static void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.highscorePlayer = playerName;
        data.highscore = highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // Load data from file
    public static void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.highscorePlayer;
            highscore = data.highscore;

        }
    }
}
