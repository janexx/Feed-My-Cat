using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Quits the current scene
    public void QuitApp()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else        
        Application.Quit();
        #endif
    }
}
