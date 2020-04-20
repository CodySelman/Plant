using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySwatter : MonoBehaviour
{
    private GameObject spriteGO;
    private BoxCollider hurtBox;
    private GameObject swatSprite;
    private bool isSwatting = false;

    private void Start()
    {
        spriteGO = transform.GetChild(0).gameObject;
        hurtBox = transform.GetChild(1).gameObject.GetComponent<BoxCollider>();
        swatSprite = hurtBox.gameObject.transform.GetChild(0).gameObject;
        swatSprite.SetActive(false);
        hurtBox.enabled = false;
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
        hurtBox.enabled = true;
        swatSprite.SetActive(true);
        spriteGO.transform.rotation = Quaternion.Euler(45, 0, 0);
        yield return new WaitForSeconds(0.15f);
        spriteGO.transform.rotation = Quaternion.Euler(0, 0, 0);
        isSwatting = false;
        hurtBox.enabled = false;
        swatSprite.SetActive(false);
    }

    public void HurtboxTrigger(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject.Destroy(other);
        }
    }
}
