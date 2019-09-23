using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Stage1");                           // Carrega a Scene
    }

    public void CreditsGame()
    {
        SceneManager.LoadScene("Credits");                           // Carrega a Scene
    }
}
