using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    private GameObject spriteGO;
    private bool isWatering = false;

    [SerializeField] private BoxCollider hurtBox;

    private void Start()
    {
        spriteGO = transform.GetChild(0).gameObject;
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
            Debug.Log("Water Plant");
        }
    }
}
