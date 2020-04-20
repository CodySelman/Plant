using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool isGameOver = false;
    public bool isHoldingObject = false;
    public float score = 0;
    private float scoreFactor = 1;
    private PlantController plantController;
    private GameObject gameOverGO;

    public TMP_Text scoreText;

    private void Start()
    {
        plantController = GameObject.FindGameObjectWithTag("Plant").GetComponent<PlantController>();
        gameOverGO = GameObject.FindGameObjectWithTag("GameOver");
        gameOverGO.SetActive(false);
        isGameOver = false;
    }

    private void Update()
    {
        if (!isGameOver)
        {
            score += scoreFactor * Time.deltaTime;
            scoreText.text = "Score: " + Mathf.FloorToInt(score);
            if (plantController.health <= 0)
            {
                isGameOver = true;
            }
        } else
        {
            gameOverGO.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
