using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isGameOver = true;
    public bool isHoldingObject = false;

    private void Start()
    {
        isGameOver = false;
    }
}
