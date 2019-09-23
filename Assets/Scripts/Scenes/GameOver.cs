using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{   // Atributos
    public Text textoPontosMax;
    public Pontos score;

    // Métodos
    void Start ()
    {
        textoPontosMax.text = "Max Score: " + PlayerPrefs.GetInt("MaxScore").ToString();
    }

	void Update ()
    {
        // verificando a quantidade total de lixo coletado
        if (PlayerPrefs.GetInt("MaxScore") < score.garbage)
        {
            PlayerPrefs.SetInt("MaxScore", score.garbage);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void MainMeu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
