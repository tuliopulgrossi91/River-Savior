using UnityEngine;
using System.Collections;

public class LifesManager : MonoBehaviour {

    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;

    public GameMotor score_Lifes;

    // Use this for initialization
    void Start () {
        Life3.SetActive(true);
        Life2.SetActive(true);
        Life1.SetActive(true);
    }
	
    void Update()
    {
        AudioCol();
    }

    void AudioCol()
    {
        if (score_Lifes.life == 2)
        {
            Life3.SetActive(false);
        }

        if (score_Lifes.life == 1)
        {
            Life2.SetActive(false);
        }

        if (score_Lifes.life < 1)
        {
            Life1.SetActive(false);
        }
    }
    }
