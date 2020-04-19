﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    private GameObject spriteGO;
    private BoxCollider hurtBox;
    private PlantController plantController;
    private bool isWatering = false;

    private void Start()
    {
        spriteGO = transform.GetChild(0).gameObject;
        hurtBox = transform.GetChild(1).gameObject.GetComponent<BoxCollider>();
        plantController = GameObject.FindGameObjectWithTag("Plant").GetComponent<PlantController>();
        hurtBox.enabled = false;
    }

    public void PrimaryAction()
    {
        if (!isWatering)
        {
            StartCoroutine(Water());
        }
    }

    IEnumerator Water()
    {
        isWatering = true;
        hurtBox.enabled = true;
        spriteGO.transform.rotation = Quaternion.Euler(0, 0, 45);
        yield return new WaitForSeconds(0.3f);
        spriteGO.transform.rotation = Quaternion.Euler(0, 0, 0);
        isWatering = false;
        hurtBox.enabled = false;
    }

    public void HurtboxTrigger(GameObject other)
    {
        if (other.CompareTag("Plant"))
        {
            plantController.GetWatered();
        }
    }
}
