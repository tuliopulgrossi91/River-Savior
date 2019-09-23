using UnityEngine;
using System.Collections;

public class Stage2 : MonoBehaviour {

    public GameObject TextStage2;
  

    // Use this for initialization
    void Start()
    {

        
        TextStage2.SetActive(true);
        StartCoroutine(Stage2Wait());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Stage2Wait()
    {
        yield return new WaitForSeconds(3);
        TextStage2.SetActive(false);
    }
}
