using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StatusGame : MonoBehaviour {

    public string scenes;

    // Use this for initialization
    void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

    public void Retry()
    {
        if (scenes == PlayerPrefs.GetString("Stage1"))
        {
            SceneManager.LoadScene("Stage1");
        }

        if (scenes == PlayerPrefs.GetString("Stage2"))
        {
            SceneManager.LoadScene("Stage2");
        }

        if (scenes == PlayerPrefs.GetString("Stage3"))
        {
            SceneManager.LoadScene("Stage3");
        }
    }
}
