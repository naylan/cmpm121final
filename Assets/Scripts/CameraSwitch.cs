using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject cameraOne;
    public GameObject cameraTwo;
    public GameObject cameraThree;

    AudioListener cameraOneAudioLis;
    AudioListener cameraTwoAudioLis;
    AudioListener cameraThreeAudioLis;

    // Use this for initialization
    void Start()
    {

        //Get Camera Listeners
        cameraOneAudioLis = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = cameraTwo.GetComponent<AudioListener>();
        cameraThreeAudioLis = cameraThree.GetComponent<AudioListener>();

        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        //Change Camera Keyboard
        switchCamera();
    }

    //Change Camera Keyboard
    void switchCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            Debug.Log("click");
            cameraPositionChange(0);

            if (hit.collider.tag == "Object1")
            {
                Debug.Log("---> Hit: ");
                cameraPositionChange(1);
            } else if (hit.collider.tag == "Object2") {
                Debug.Log("---> Hit: 2");
                cameraPositionChange(2);
            }
        }
    }

    ////Camera Counter
    //void cameraChangeCounter()
    ////{
    ////    int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
    ////    cameraPositionCounter++;
    ////    cameraPositionChange(cameraPositionCounter);
    ////}

    //Camera change Logic
    void cameraPositionChange(int camPosition)
    {
        //if (camCount > 2)
        //{
        //    camCount = 0;
        //}

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set camera position 1
        if (camPosition == 0)
        {
            cameraOne.SetActive(true);
            cameraOneAudioLis.enabled = true;

            cameraTwoAudioLis.enabled = false;
            cameraTwo.SetActive(false);

            cameraThree.SetActive(false);
            cameraThreeAudioLis.enabled = false;
        }

        //Set camera position 2
        if (camPosition == 1)
        {
            cameraTwo.SetActive(true);
            cameraTwoAudioLis.enabled = true;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraThree.SetActive(false);
            cameraThreeAudioLis.enabled = false;
        }

        if (camPosition == 2)
        {
            cameraThree.SetActive(true);
            cameraThreeAudioLis.enabled = true;

            cameraTwoAudioLis.enabled = false;
            cameraTwo.SetActive(false);

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);
        }
    }
}
