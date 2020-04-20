using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    private Rigidbody rb;
    private GameController gameController;

    public float health = 100f;

    public float wetness = 100f;
    private float wetnessLoss = 4;
    public int wetnessThreshold = 25;
    private float wetnessDamage = 4;

    public float hunger = 100f;
    private float hungerLoss = 2;
    public int hungerThreshold = 25;
    private float hungerDamage = 8;

    public float sunlight = 100f;

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

            UpdateHunger(hunger -= hungerLoss * Time.deltaTime);
            if (hunger <= hungerThreshold)
            {
                UpdateHealth(health -= hungerDamage * Time.deltaTime);
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
        if (newHealth <= 0)
        {
            gameController.isGameOver = true;
        }
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

    public void GetFertilized()
    {
        UpdateHunger(hunger += 25f);
    }

    private void UpdateHunger(float newHunger)
    {
        hunger = Mathf.Clamp(newHunger, 0, 100f);
    }
}
