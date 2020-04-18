using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillarSpawner : MonoBehaviour
{
    public GameObject caterpillar;

    private void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        GameObject.Instantiate(caterpillar, transform);
    }
}
