using UnityEngine;
using System.Collections;

public class Stage3 : MonoBehaviour {

    public GameObject TextStage3;
   

    // Use this for initialization
    void Start()
    {
        
        TextStage3.SetActive(true);
        StartCoroutine(Stage3Wait());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Stage3Wait()
    {
        yield return new WaitForSeconds(3);
        TextStage3.SetActive(false);
    }
}
