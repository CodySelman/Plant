using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBars : MonoBehaviour
{
    private PlantController plantController;
    private Slider healthSlider;
    private Slider wetSlider;
    private Slider fertilizerSlider;
    private Slider sunSlider;

    private Image wetFill;
    private Image fertilizerFill;

    private Color32 wetColor1 = new Color32(44, 163, 185, 255);
    private Color32 wetColor2 = new Color32(27, 99, 112, 255);
    private Color32 fertilizerColor1 = new Color32(114, 38, 121, 255);
    private Color32 fertilizerColor2 = new Color32(69, 11, 74, 255);

    private void Start()
    {
        plantController = GameObject.FindGameObjectWithTag("Plant").GetComponent<PlantController>();
        foreach(Transform child in transform)
        {
            switch (child.gameObject.name)
            {
                case "Health Bar":
                    healthSlider = child.gameObject.GetComponent<Slider>();
                    break;
                case "Wet Bar":
                    wetSlider = child.gameObject.GetComponent<Slider>();
                    wetFill = child.gameObject.transform.GetChild(1).gameObject.GetComponent<Image>();
                    break;
                case "Fertilizer Bar":
                    fertilizerSlider = child.gameObject.GetComponent<Slider>();
                    fertilizerFill = child.gameObject.transform.GetChild(1).gameObject.GetComponent<Image>();
                    break;
                case "Sun Bar":
                    sunSlider = child.gameObject.GetComponent<Slider>();
                    break;
                default:
                    break;
            }
        }
    }

    private void Update()
    {
        healthSlider.value = plantController.health;
        wetSlider.value = plantController.wetness;
        fertilizerSlider.value = plantController.hunger;
        sunSlider.value = plantController.sunlight;

        if (wetSlider.value <= plantController.wetnessThreshold)
        {
            wetFill.color = wetColor2;
        } else
        {
            wetFill.color = wetColor1;
        }

        if (fertilizerSlider.value <= plantController.hungerThreshold)
        {
            fertilizerFill.color = fertilizerColor2;
        }
        else
        {
            fertilizerFill.color = fertilizerColor1;
        }
    }
}
