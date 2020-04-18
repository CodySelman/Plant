﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySwatter : MonoBehaviour
{
    private GameObject spriteGO;
    private bool isSwatting = false;

    public BoxCollider hurtBoxGO;

    private void Start()
    {
        spriteGO = transform.GetChild(0).gameObject;
        hurtBoxGO.enabled = false;
    }

    public void PrimaryAction()
    {
        if (!isSwatting)
        {
            StartCoroutine(Swat());
        }
    }

    IEnumerator Swat()
    {
        isSwatting = true;
        hurtBoxGO.enabled = true;
        spriteGO.transform.rotation = Quaternion.Euler(45, 0, 0);
        yield return new WaitForSeconds(0.15f);
        spriteGO.transform.rotation = Quaternion.Euler(0, 0, 0);
        isSwatting = false;
        hurtBoxGO.enabled = false;
    }

    public void HurtboxTrigger(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject.Destroy(other);
        }
    }
}