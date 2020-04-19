﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    // Credit: Jayanam Games

    private GameController gameController;

    private Vector3 mouseOffset;
    private float mouseZ;
    private bool isHeld = false;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnMouseDown()
    {
        if (!gameController.isHoldingObject)
        {
            isHeld = true;
            gameController.isHoldingObject = true;

            mouseZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

            // Store offset = gameobject world pos - mouse world pos
            mouseOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        }
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mouseZ;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if (isHeld)
        {
            transform.position = GetMouseAsWorldPoint() + mouseOffset;
        }
    }

    private void OnMouseUp()
    {
        isHeld = false;
        gameController.isHoldingObject = false;
    }
}
