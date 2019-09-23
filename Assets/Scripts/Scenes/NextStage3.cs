using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextStage3 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

    }

    public void NextStage()
    {
        SceneManager.LoadScene("Stage3");
    }
}
