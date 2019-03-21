using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject winning;
    public GameObject textbox10;

    // Update is called once per frame
    void Update()
    {
        if (CountManager.counter >= 5 && Input.GetKeyDown("space")) {
            CountManager.counter = 0;
            SceneManager.LoadScene(0);
        }
    }
}
