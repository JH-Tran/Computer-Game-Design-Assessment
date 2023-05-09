using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeDoorBasket : ColourDoorObjectPlate
{
    [SerializeField] private GameObject reactor;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == keyMaterial.name + " (Instance)")
            {
                reactor.GetComponent<Reactor>().activateReactor();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == keyMaterial.name + " (Instance)")
            {
                reactor.GetComponent<Reactor>().deactivateReactor();
            }
        }
    }
}
