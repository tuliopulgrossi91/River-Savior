using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StatusManager : MonoBehaviour {

    public GameObject ProgressMessage1, ProgressMessage2, ProgressMessage3;
    public GameObject LifeMessage1, LifeMessage2;
    public GameObject Life1, Life2, Life3;
    public Pontos score;
    public GameMotor player;

    void Start ()
    {
        Life3.SetActive(true);
        Life2.SetActive(true);
        Life1.SetActive(true);

        LifeMessage1.SetActive(false);
        LifeMessage2.SetActive(false);

        ProgressMessage1.SetActive(false);
        ProgressMessage2.SetActive(false);
        ProgressMessage3.SetActive(false);
    }

	void Update ()
    {
        LifeMessages();
        ProgressMessages();
    }

    void LifeMessages()
    {
        if (player.life == 2)
        {
            Life3.SetActive(false);
            LifeMessage1.SetActive(true);
            StartCoroutine(LifeWait());
        }
        if (player.life == 1)
        {
            Life2.SetActive(false);
            LifeMessage1.SetActive(false);
            LifeMessage2.SetActive(true);
            StartCoroutine(LifeWait());
        }
        if (player.life < 1)
        {
            Life1.SetActive(false);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void ProgressMessages()
    {
        if (score.garbage == 10)
        {
            ProgressMessage1.SetActive(true);
            StartCoroutine(ProgressWait());
        }

        if (score.garbage == 25)
        {
            ProgressMessage2.SetActive(true);
            StartCoroutine(ProgressWait());
        }

        if (score.garbage == 45)
        {
            ProgressMessage3.SetActive(true);
            StartCoroutine(ProgressWait());
        }
    }

    IEnumerator LifeWait()
    {
        yield return new WaitForSeconds(5);
        LifeMessage1.SetActive(false);
        LifeMessage2.SetActive(false);
    }

    IEnumerator ProgressWait()
    {
        yield return new WaitForSeconds(3);

        ProgressMessage1.SetActive(false);
        ProgressMessage2.SetActive(false);
        ProgressMessage3.SetActive(false);
    }
}
