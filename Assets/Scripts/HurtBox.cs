using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HurtBox : MonoBehaviour
{
    [SerializeField] private GameObject flySwatterGO;
    private FlySwatter flySwatterScript;

    private void Start()
    {
        flySwatterScript = flySwatterGO.GetComponent<FlySwatter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        flySwatterScript.HurtboxTrigger(other.transform.gameObject);
    }
}
