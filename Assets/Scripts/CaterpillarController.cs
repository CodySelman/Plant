using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillarController : MonoBehaviour
{
    private GameObject plant;
    [SerializeField] private float speed;
    [SerializeField] private float strength;

    private void Start()
    {
        plant = GameObject.FindGameObjectWithTag("Plant");
    }

    private void Update()
    {
        if (plant.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position = Vector3.MoveTowards(transform.position, plant.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // TODO prevent multiple simultaneous collisions
        if (collision.gameObject.CompareTag("Plant"))
        {
            PlantController plantController = collision.gameObject.GetComponent<PlantController>();
            if (plantController)
            {
                plantController.GetHit(strength, transform.position);
            } else
            {
                Debug.Log("Plant gameObject missing PlantController script.");
            }

        }
    }
}
