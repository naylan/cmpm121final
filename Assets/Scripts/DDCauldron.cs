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
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
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
        if (Mathf.Abs(transform.position.x - CauldronPlace.position.x) <= 0.1f &&
            Mathf.Abs(transform.position.y - CauldronPlace.position.y) <= 0.1f)
            {
            if (CountManager.counter < 1 && !CountManager.cauldronBase)
            {
                transform.position = new Vector2(CauldronPlace.position.x, CauldronPlace.position.y + 0.045f);
                locked = true;
                CountManager.cauldronBase = true;
                CountManager.counter++;
                Debug.Log("cauldronBase = true");
            }
            }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
            Debug.Log("cauldronBase = false");
        }
    }
}
