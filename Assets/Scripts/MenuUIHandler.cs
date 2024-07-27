using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputfield;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set static player name in MainManager
    public void SetPlayerName(String name)
    {
        MainManager.playerName = inputfield.text;
        Debug.Log("Player Name is: " + MainManager.playerName);
    }


}
