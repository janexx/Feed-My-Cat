using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadCatGame()
    {
        SceneManager.LoadScene("CerealCountGame");
    }

}
