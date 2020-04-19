using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HurtBox : MonoBehaviour
{
    private GameObject parentGO;
    private FlySwatter flySwatterScript;
    private WateringCan wateringCanScript;

    private void Start()
    {
        parentGO = transform.parent.gameObject;

        switch(parentGO.name)
        {
            case "Fly Swatter":
                flySwatterScript = parentGO.GetComponent<FlySwatter>();
                break;
            case "Watering Can":
                wateringCanScript = parentGO.GetComponent<WateringCan>();
                break;
            default:
                Debug.Log("HurtBox can't find parent Game Object");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (parentGO.name)
        {
            case "Fly Swatter":
                flySwatterScript.HurtboxTrigger(other.transform.gameObject);
                break;
            case "Watering Can":
                wateringCanScript.HurtboxTrigger(other.transform.gameObject);
                break;
            default:
                Debug.Log("HurtBox can't find parent Game Object");
                break;
        }
        
    }
}
