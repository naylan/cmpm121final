using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDCauldron : CountManager
{
    [SerializeField]
    private Transform CauldronPlace;

    public static bool locked;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    public GameObject fire;
    public GameObject litCauldron;
    public GameObject nonlitC;
    public GameObject secondClue;
    public GameObject textbox4;
    public GameObject thirdClue;
    public GameObject textbox5;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        anim = GetComponent<Animator>();
        thirdClue.SetActive(false);
        textbox5.SetActive(false);

    }

    private void OnMouseDown()
    {
        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
            Debug.Log("drag");
        }
    }

    private void OnMouseUp()
    {
        //if (Mathf.Abs(transform.position.x - CauldronPlace.position.x) <= 0.1f &&
            //Mathf.Abs(transform.position.y - CauldronPlace.position.y) <= 0.1f)
            //{
            if (CountManager.counter < 1 && !CountManager.cauldronBase && CountManager.fireOn)
            {
                fire.SetActive(false);
                nonlitC.SetActive(false);
                litCauldron.SetActive(true);
                //transform.position = new Vector2(CauldronPlace.position.x, CauldronPlace.position.y + 0.045f);
                locked = true;
                CountManager.cauldronBase = true;
                CountManager.counter++;
                Debug.Log("cauldronBase = true");
                Destroy(secondClue);
                Destroy(textbox4);
                thirdClue.SetActive(true);
                textbox5.SetActive(true);

        }
            //}
        else
        {
            CountManager.cauldronBase = false;
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
            Debug.Log("cauldronBase = false");
        }
    }
}
