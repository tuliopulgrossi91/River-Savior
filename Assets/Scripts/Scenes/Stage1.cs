using UnityEngine;
using System.Collections;

public class Stage1 : MonoBehaviour
{
    public GameObject TextStage1;


    // Use this for initialization
    void Start () {

      
        TextStage1.SetActive(true);
        StartCoroutine(Stage1Wait());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Stage1Wait()
    {
        yield return new WaitForSeconds(3);
        TextStage1.SetActive(false);
    }
}
