using UnityEngine;
using System.Collections;

public class Messages : MonoBehaviour {

    public GameObject PanelMessage1;
    public GameObject PanelMessage2;
    public GameObject PanelMessage3;

    public Pontos score;

    // Use this for initialization
    void Start () {
        PanelMessage1.SetActive(false);
        PanelMessage2.SetActive(false);
        PanelMessage3.SetActive(false);
    }

	
	// Update is called once per frame
	void Update () {

        if (score.garbage == 5)
        {
            PanelMessage1.SetActive(true);
            StartCoroutine(Msg1Wait());
        }

        if (score.garbage == 15)
        {
            PanelMessage2.SetActive(true);
            StartCoroutine(Msg2Wait());
        }

        if (score.garbage == 45)
        {
            PanelMessage3.SetActive(true);
            StartCoroutine(Msg3Wait());
        }
    }

    IEnumerator Msg1Wait()
    {
        yield return new WaitForSeconds(5);
        PanelMessage1.SetActive(false);
    }

    IEnumerator Msg2Wait()
    {
        yield return new WaitForSeconds(5);
        PanelMessage2.SetActive(false);
    }

    IEnumerator Msg3Wait()
    {
        yield return new WaitForSeconds(5);
        PanelMessage3.SetActive(false);
    }
}
