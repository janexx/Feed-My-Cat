using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 1;
    public int score = 0;
    private int scoreTreshold = 10;
    private int highscore;

    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI levelText;
    public TextMeshProUGUI txtHighscorePlayerName;
    public TextMeshProUGUI txt_highscore;

    private static TextMeshProUGUI catText;
    private PlayerControler playerControler;
    public CerealsSpawnManager spawnManager ;
    public AudioSource ambientMusic;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponentInChildren<TextMeshProUGUI>();
        levelText = GameObject.FindGameObjectWithTag("Level").GetComponentInChildren<TextMeshProUGUI>();        
        playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
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
        UpdateLevel();


        if (playerControler != null)
        {
            Debug.Log($"gameIsOver Status: {playerControler.gameIsOver}");
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

    // Erhöhe alle 100 Punkte (Treshold) das Level
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
        scoreText.text = "Score :" + score;
        if(playerControler != null)
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
        Debug.Log("Player score: " + score);
    }

    IEnumerator WaitForGameEnding()
    {
        Debug.Log("Wait for Game ending");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("GameOver");
    }



}
