using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;


    // Update score with value from food item
     public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score :" + score;
    }
}
