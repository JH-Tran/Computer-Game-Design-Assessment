using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourDoorObjectPlate : MonoBehaviour
{
    //If the object has the same material as the door the door "opens".
    [SerializeField] private Material keyMaterial;
    [SerializeField] private Animator doorAnimator;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == keyMaterial.name + " (Instance)")
            {
                doorAnimator.SetBool("isDoorOpen", true);
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
            }
        }
    }
}
