using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{   // Atributos
    public Pontos score;
    public GameMotor player;
    public bool seenC = false, seenW = false; 
    public GameObject PanelPause, Life1, Life2, Life3, textoColeta;
    public GameObject MessageNice, MessageGood, MessageGreat, MessageCaution, MessageWarning;

    // Métodos
    void Start()
    {
        Loader();
    }

    void Update()
    {
        //GameStatus();                                                // Ativa os Paineis e Pausa o Jogo
        LifeMessages();
        ProgressMessages();
    }

    void Loader()
    {
        Time.timeScale = 1;

        MessageCaution.SetActive(false);
        MessageWarning.SetActive(false);

        MessageNice.SetActive(false);
        MessageGood.SetActive(false);
        MessageGreat.SetActive(false);
    }

    void LifeMessages()
    {
        if (player.life == 2 && seenC == false)
        {
            Life3.SetActive(false);
            MessageCaution.SetActive(true);
            StartCoroutine(Contador(1));            //Chama o contador com um código
            seenC = true;
        }

        if (player.life == 1 && seenW == false)
        {
            Life2.SetActive(false);
            MessageCaution.SetActive(false);
            MessageWarning.SetActive(true);
            StartCoroutine(Contador(2));            //Chama o contador com um código
            seenW = true;
        }

        if (player.life == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void ProgressMessages()
    { 
        if (score.garbage == 10)
        {
            MessageNice.SetActive(true);
            StartCoroutine(Contador(3));            //Chama o contador com um código
        }

        if (score.garbage == 25)
        {
            MessageGood.SetActive(true);
            StartCoroutine(Contador(3));            //Chama o contador com um código
        }

        if (score.garbage == 45)
        {
            MessageGreat.SetActive(true);
            StartCoroutine(Contador(3));            //Chama o contador com um código
        }
    }

    IEnumerator Contador(int code)
    {
        if (code == 1)
        {
            yield return new WaitForSeconds(4);
            MessageCaution.SetActive(false);
        }
        else if (code == 2)
        {
            yield return new WaitForSeconds(3);
            MessageWarning.SetActive(false);
        }
        else if (code == 3)
        {
            yield return new WaitForSeconds(2);
            MessageNice.SetActive(false);
            MessageGood.SetActive(false);
            MessageGreat.SetActive(false);
        }
    }

    /*void GameStatus()
    {
        if (textoColeta.activeSelf == true)                         // Se der ESC, Menu e Start o jogo não fica pausado
        {
            
        } 

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("PauseButton-XBOX360"))
		{
                PauseGame();                                        // Pausa
        }
    }*/

    public void StartGame()
    {
        SceneManager.LoadScene("Stage1");                           // Carrega a Scene
        Cursor.visible = false;                                     // Cursor Invisível
        Time.timeScale = 1;                                         // O TEMPO SEGUE
    }

    public void PauseGame()
    {
        PanelPause.SetActive(true);                     // Painel de Pausa é Ativado
        textoColeta.SetActive(false);
        Cursor.visible = true;                              // Cursor Visível
        Time.timeScale = 0;                                 // O TEMPO PARA
    }

    public void ResumeGame()                                        // Método que Retorna ao Jogo
    {
        PanelPause.SetActive(false);                    // Painel de Pausa é Desativado
        textoColeta.SetActive(true);
        Cursor.visible = false;                             // Cursor Invisível
        Time.timeScale = 1;                                 // O TEMPO SEGUE
    }

    public void RetryGame()                                         // Método que Reinicia o Jogo
    {
        SceneManager.LoadScene("Stage1");                           // Carrega a Scene
        Cursor.visible = false;                                     // Cursor Invisível
        Time.timeScale = 1;                                         // O TEMPO SEGUE
    }

    public void MenuGame()                                         // Método que acessa menu do jogo
    {
        SceneManager.LoadScene("MainMenu");                           // Carrega a Scene
    }
}