using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    private Rigidbody rb;
    private GameController gameController;

    private float health = 100f;

    private float wetness = 100f;
    private float wetnessLoss = 2;
    private int wetnessThreshold = 25;
    private float wetnessDamage = 1;

    private float hunger = 100f;
    private float sunlight = 100f;

    private float hungerLoss = 1;
    private float sunlightLoss = 1;


    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < 0.2)
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void Update()
    {
        if (!gameController.isGameOver)
        {
            UpdateWetness(wetness -= wetnessLoss * Time.deltaTime);
            if (wetness <= wetnessThreshold)
            {
                UpdateHealth(health -= wetnessDamage * Time.deltaTime);
            }
        }
    }

    public void GetHit(float damage, Vector3 attackerPos)
    {
        UpdateHealth(health -= damage);
        Vector3 attackerDir = attackerPos - transform.position;
        Vector3 recoilDir = -attackerDir.normalized;
        rb.AddForce(recoilDir * (damage / 7.5f), ForceMode.Impulse);
    }

    private void UpdateHealth(float newHealth)
    {
        health = Mathf.Clamp(newHealth, 0, 100f);
    }

    public void GetWatered()
    {
        UpdateWetness(wetness += 25f);
    }

    private void UpdateWetness(float newWetness)
    {
        wetness = Mathf.Clamp(newWetness, 0, 100f);
    }
}
