using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowFinalScore : MonoBehaviour
{
    public TextMeshProUGUI textYourCount;
    public TextMeshProUGUI textHighscore;


    // Start is called before the first frame update
    void Start()
    {
        textHighscore.text = "Highscore: " + MainManager.GetHighscore();

        if (GameManager.highscoreIsBeaten)
        {
            textYourCount.text = "You have collected " + MainManager.GetPlayerScore().ToString() + " frootloops for Kitty and beat the highscore!";
        }

        else
        {
            textYourCount.text = "You have collected " + MainManager.GetPlayerScore().ToString() + " frootloops for Kitty!";
        }
    }

    // Update is called once per frame
    void Update()    {      
        

    }
}
