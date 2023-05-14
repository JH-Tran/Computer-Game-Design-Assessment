using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeDoorBasket : ColourDoorObjectPlate
{
    [SerializeField] private GameObject reactor;
    public AudioSource secretTrigger;
    private bool soundIsPlayed = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == keyMaterial.name + " (Instance)")
            {
                doorAnimator.SetBool("isDoorOpen", true);
                reactor.GetComponent<Reactor>().activateReactor();
                if (soundIsPlayed == false)
                {
                    secretTrigger.Play();
                    soundIsPlayed = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == keyMaterial.name + " (Instance)")
            {
                doorAnimator.SetBool("isDoorOpen", false);
                reactor.GetComponent<Reactor>().deactivateReactor();
                soundIsPlayed = false;
            }
        }
    }
}
