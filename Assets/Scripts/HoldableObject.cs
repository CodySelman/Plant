﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoldableObject : MonoBehaviour
{
    private GameController gameController;
    private Vector3 mouseOffset;
    private float mouseZ = 0;
    private bool isHeld = false;

    public UnityEvent primaryAction;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (isHeld)
        {
            transform.position = GetMouseAsWorldPoint() + mouseOffset;

            if (Input.GetMouseButtonDown(0))
            {
                primaryAction.Invoke();
            } else if (Input.GetMouseButtonDown(1))
            {
                isHeld = false;
                gameController.isHoldingObject = false;
            }
        }
    }

    void OnMouseDown()
    {
        if (!gameController.isHoldingObject)
        {
            mouseZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

            // Store offset = gameobject world pos - mouse world pos
            mouseOffset = gameObject.transform.position - GetMouseAsWorldPoint();

            isHeld = true;
            gameController.isHoldingObject = true;
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
}
