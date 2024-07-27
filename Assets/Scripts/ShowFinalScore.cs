using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowFinalScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    private Counter counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = counter.CounterText.text;
        text.text = "You have collected " + Counter.Count.ToString() + " frootloops for Kitty!";
    }
}
