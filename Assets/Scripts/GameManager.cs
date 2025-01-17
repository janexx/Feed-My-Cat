using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 1;
    public static int score = 0;
    private int scoreTreshold = 10;
    public static bool highscoreIsBeaten;

    private TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerName;
    private TextMeshProUGUI levelText;
    public TextMeshProUGUI txtHighscorePlayerName;
    public TextMeshProUGUI txtHighscore;

    private static TextMeshProUGUI catText;
    private PlayerControler playerControler;
    public CerealsSpawnManager spawnManager ;
    public AudioSource ambientMusic;

    // Start is called before the first frame update
    void Start()
    {
        // Print GUI text elements
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponentInChildren<TextMeshProUGUI>();
        levelText = GameObject.FindGameObjectWithTag("Level").GetComponentInChildren<TextMeshProUGUI>();        
        playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        playerName.text = MainManager.GetPlayerName();
        // Initialization
        currentLevel = 1;
        score = 0;
        highscoreIsBeaten = false;
        // Load current Highscore
        MainManager.LoadHighscore();
        
    }

    public void StartGame()
    {
        spawnManager.Spawn();
        ambientMusic.Play();
        catText = GameObject.FindGameObjectWithTag("CatSpeech").GetComponent<TextMeshProUGUI>();
        catText.text = "I am hungry!";        
    }


    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level: " + currentLevel;
        scoreText.text = "Score :" + score;
        UpdateLevel();

        // Update highscore on screen
        CalculateHighscore();
        PrintHighscore();



        if (playerControler != null)
        {
            if (playerControler.gameIsOver)
            {
                Debug.Log("Quit Game");
                EndGame();                
            }
        }
        else
        {
            Debug.Log("playerControler ist null");
        }
    }

    // Erh�he alle 100 Punkte (Treshold) das Level
    public void UpdateLevel()
    {
        int newLevel = score / scoreTreshold;
        if (newLevel >= currentLevel)
        {
            currentLevel++;
            spawnManager.FastenEnemySpawnTime(0.2f);
            Debug.Log("Level " + currentLevel + " erreicht!");            
        }
    }

    
    // Update score with value from food item and show it on Canvas
    public void UpdateScore(int scoreToAdd)
    {
        // Get current score from Food which was collected  
        score += scoreToAdd;
        Debug.Log("Updated core: " + score);
        if (playerControler != null)
        {
            playerControler.foodIsCollected = false;
        }        
    }

    public void SetCatText(string newText)
    {
        catText.text = newText;
    }

    private void EndGame()
    {
        spawnManager.StopSpawning();
        spawnManager.DestroyCereals();
        ambientMusic.Stop();
        StartCoroutine("WaitForGameEnding");
        //Save Score in MainManager
        MainManager.SetPlayerScore(score);
        // Save Highscore data in externa JSON file
        MainManager.SaveHighscore();
        Debug.Log("Player score: " + score);
    }

    IEnumerator WaitForGameEnding()
    {
        Debug.Log("Wait for Game ending");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("GameOver");
    }

    private void CalculateHighscore()
    {
        // When current score > highscore, the current score is the new highscore, the currect player gets highscore-player
        if (score > MainManager.highscore)
        {
            MainManager.highscore = score;
            MainManager.highscorePlayer = MainManager.playerName;
            highscoreIsBeaten = true;
        }
    }

    private void PrintHighscore()
    {
        txtHighscore.text = MainManager.highscore.ToString();       
        txtHighscorePlayerName.text = MainManager.GetPlayerName();
        Debug.Log("Highscore: " + txtHighscorePlayerName.text + "  " +  txtHighscore.text);
    }


}
