﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDChains : CountManager
{
    [SerializeField]
    private Transform itemPlace;

    public static bool locked;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    public GameObject seventhClue;
    public GameObject textbox9;
    public GameObject winning;
    public GameObject textbox10;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        winning.SetActive(false);
        textbox10.SetActive(false);
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
            if (CountManager.counter == 5 && CountManager.cauldronBase == true)
            {
                transform.position = new Vector2(itemPlace.position.x, itemPlace.position.y + 0.045f);
                locked = true;
                CountManager.counter++;
                Debug.Log("5th locked!!!");
                Destroy(seventhClue);
                Destroy(textbox9);
                winning.SetActive(true);
                textbox10.SetActive(true);
        }
        //}
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }
}
