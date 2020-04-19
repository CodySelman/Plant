using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject caterpillar;
    private GameController gameController;
    private float screenWidth;
    private float screenHeight;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Vector3 screenDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        screenWidth = screenDimensions.x;
        screenHeight = screenDimensions.y;

        Spawn();
    }

    private void Spawn()
    {
        int randomInt = Mathf.FloorToInt(Random.Range(0, 4));
        if (randomInt >= 3)
        {
            SpawnLeft();
        } else if (randomInt >= 2)
        {
            SpawnRight();
        } else if (randomInt >= 1)
        {
            SpawnTop();
        } else
        {
            SpawnBottom();
        }
    }

    private float GetRandomWidth()
    {
        return Random.Range(-screenWidth, screenWidth);
    }

    private float GetRandomHeight()
    {
        return Random.Range(-screenHeight, screenHeight);
    }

    private void SpawnLeft()
    {
        float posX = -(screenWidth + 1);
        float posY = GetRandomHeight();
        Vector3 spawnPos = new Vector3(posX, posY, 0);
        SpawnCaterpillar(spawnPos);
    }

    private void SpawnRight()
    {
        float posX = screenWidth + 1;
        float posY = GetRandomHeight();
        Vector3 spawnPos = new Vector3(posX, posY, 0);
        SpawnCaterpillar(spawnPos);
    }

    private void SpawnTop()
    {
        float posX = GetRandomWidth();
        float posY = screenHeight + 1;
        Vector3 spawnPos = new Vector3(posX, posY, 0);
        SpawnCaterpillar(spawnPos);
    }

    private void SpawnBottom()
    {
        float posX = GetRandomWidth();
        float posY = -(screenHeight + 1);
        Vector3 spawnPos = new Vector3(posX, posY, 0);
        SpawnCaterpillar(spawnPos);
    }

    private void SpawnCaterpillar(Vector3 pos)
    {
        GameObject.Instantiate(caterpillar, pos, Quaternion.identity);
    }
}
