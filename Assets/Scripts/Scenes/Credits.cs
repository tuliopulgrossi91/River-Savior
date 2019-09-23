using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public AudioSource audio_effect;

    void Start()
    {
        Debug.Log("Cena Créditos");
    }

   void Update()
    {       
            // se pressionar qualquer botão - voltar para menu
            if (Input.anyKey)
            {
            audio_effect.Play();
            SceneManager.LoadScene("MainMenu");
        }
        }

       
}