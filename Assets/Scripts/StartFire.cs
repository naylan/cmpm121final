using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFire : MonoBehaviour
{
    Animator anim;
    public GameObject wood;
    public GameObject fire;
    public GameObject firstClue;
    public GameObject textbox3;
    public GameObject secondClue;
    public GameObject textbox4;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        secondClue.SetActive(false);
        textbox4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 click = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D coll = wood.GetComponent<Collider2D>();

            if (coll.OverlapPoint(click)) {
                CountManager.fireOn = true;
                wood.SetActive(false);
                fire.SetActive(true);
                Destroy(firstClue);
                Destroy(textbox3);
                secondClue.SetActive(true);
                textbox4.SetActive(true);
            }
        }
    }
}
