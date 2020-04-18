using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    private float health = 100f;
    private float wetness = 100f;
    private float hunger = 100f;
    private float sunlight = 100f;

    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
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

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < 0.2)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
