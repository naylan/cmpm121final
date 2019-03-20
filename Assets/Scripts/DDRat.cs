using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDRat : CountManager
{
    //private bool selected;
    [SerializeField]
    private Transform itemPlace;

    public static bool locked;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //if (selected == true) {
    //    //    if (!locked) {
    //    //    Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    //    transform.position = new Vector2(cursorPos.x, cursorPos.y);
    //    //    }
    //    //}

    //    //if (Input.GetMouseButtonUp(0)) {

    //    //    selected = false;
    //    //}
    //}

    private void OnMouseDown() {
        if (!locked) {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag() {
        if (!locked) {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    private void OnMouseUp() {
        if (Mathf.Abs(transform.position.x - itemPlace.position.x) <= 0.1f &&
            Mathf.Abs(transform.position.y - itemPlace.position.y) <= 0.1f)
        {
            if (CountManager.counter < 2 && CountManager.cauldronBase == true)
            {
                transform.position = new Vector2(itemPlace.position.x, itemPlace.position.y + 0.045f);
                locked = true;
                CountManager.counter++;
                Debug.Log("locked!!!");
            }
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }

    //void OnMouseOver() {
    //    if (Input.GetMouseButtonDown(0)) {
    //        selected = true;
    //    }
    //}
}
