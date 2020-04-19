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
                    break;
                case "Fertilizer Bar":
                    fertilizerSlider = child.gameObject.GetComponent<Slider>();
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
    }
}
