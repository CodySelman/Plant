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

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        while (!gameController.isGameOver)
        {
            int randomInt = Mathf.FloorToInt(Random.Range(0, 4));
            if (randomInt >= 3)
            {
                SpawnLeft();
            }
            else if (randomInt >= 2)
            {
                SpawnRight();
            }
            else if (randomInt >= 1)
            {
                SpawnTop();
            }
            else
            {
                SpawnBottom();
            }
            yield return new WaitForSeconds(GetSpawnWait());
        }
        yield return null;
    }

    private float GetSpawnWait()
    {
        float score = gameController.score;
        if (score >= 1)
        {
            float waitTime = 3.0f - score / 30;
            return Mathf.Clamp(waitTime, 1.5f, 3.0f);
        } else
        {
            return 3.0f;
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
        Debug.Log("Spawn Caterpillar");
        GameObject.Instantiate(caterpillar, pos, Quaternion.identity);
    }
}
