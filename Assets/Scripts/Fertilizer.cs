using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilizer : MonoBehaviour
{
    private GameObject spriteGO;
    private PlantController plantController;
    private GameObject fertilizerPour;
    private bool isFertilizing = false;
    private BoxCollider hurtBox;

    private void Start()
    {
        spriteGO = transform.GetChild(0).gameObject;
        hurtBox = transform.GetChild(1).gameObject.GetComponent<BoxCollider>();
        fertilizerPour = hurtBox.transform.GetChild(0).gameObject;
        fertilizerPour.SetActive(false);
        plantController = GameObject.FindGameObjectWithTag("Plant").GetComponent<PlantController>();
        hurtBox.enabled = false;
    }

    public void PrimaryAction()
    {
        if (!isFertilizing)
        {
            StartCoroutine(Fertilize());
        }
    }

    IEnumerator Fertilize()
    {
        isFertilizing = true;
        hurtBox.enabled = true;
        fertilizerPour.SetActive(true);
        spriteGO.transform.rotation = Quaternion.Euler(0, 0, 90);
        yield return new WaitForSeconds(0.3f);
        spriteGO.transform.rotation = Quaternion.Euler(0, 0, 0);
        isFertilizing = false;
        hurtBox.enabled = false;
        fertilizerPour.SetActive(false);
    }

    public void HurtboxTrigger(GameObject other)
    {
        if (other.CompareTag("Plant"))
        {
            plantController.GetFertilized();
        }
    }
}
