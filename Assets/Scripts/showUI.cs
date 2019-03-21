using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showUI : MonoBehaviour
{
    public GameObject welcome;
    public GameObject textbox;
    public GameObject instruct;
    public GameObject textbox2;
    public GameObject firstClue;
    public GameObject textbox3;
    // Start is called before the first frame update
    void Start()
    {
        instruct.SetActive(false);
        textbox2.SetActive(false);
        firstClue.SetActive(false);
        textbox3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            welcome.SetActive(false);
            textbox.SetActive(false);
            instruct.SetActive(true);
            textbox2.SetActive(true);
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(5);
        Destroy(welcome);
        Destroy(textbox);
        Destroy(instruct);
        Destroy(textbox2);
        firstClue.SetActive(true);
        textbox3.SetActive(true);
    }
}
