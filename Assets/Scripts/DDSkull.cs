using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDSkull : CountManager
{
    [SerializeField]
    private Transform itemPlace;

    public static bool locked;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    public GameObject fourthClue;
    public GameObject textbox6;
    public GameObject fifthClue;
    public GameObject textbox7;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        fifthClue.SetActive(false);
        textbox7.SetActive(false);
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
        }
    }

    private void OnMouseUp()
    {
        //if (Mathf.Abs(transform.position.x - itemPlace.position.x) <= 0.1f &&
        //    Mathf.Abs(transform.position.y - itemPlace.position.y) <= 0.1f)
        //{
            if (CountManager.counter == 2 && CountManager.cauldronBase == true)
            {
                transform.position = new Vector2(itemPlace.position.x, itemPlace.position.y + 0.045f);
                locked = true;
                CountManager.counter++;
                Debug.Log("2nd locked!!!");
                Destroy(fourthClue);
                Destroy(textbox6);
                fifthClue.SetActive(true);
                textbox7.SetActive(true);
        }
        //}
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }
}
