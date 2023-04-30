using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiColourObjectPlate : MonoBehaviour
{
    [SerializeField] private Material greyMaterial;
    [SerializeField] private Material yellowMaterial;
    [SerializeField] private Material redMaterial;


    [SerializeField] private Animator greyDoorAnimator;
    [SerializeField] private Animator yellowDoorAnimator;
    [SerializeField] private Animator[] redDoorAnimator;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == greyMaterial.name + " (Instance)")
            {
                greyDoorAnimator.SetBool("isDoorOpen", true);
            }
            else if (other.GetComponent<Renderer>().material.name == yellowMaterial.name + " (Instance)")
            {
                yellowDoorAnimator.SetBool("isDoorOpen", true);
            }
            else if (other.GetComponent<Renderer>().material.name == redMaterial.name + " (Instance)")
            {
                foreach(Animator redAnimator in redDoorAnimator)
                {
                    redAnimator.SetBool("isDoorOpen", true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == greyMaterial.name + " (Instance)")
            {
                greyDoorAnimator.SetBool("isDoorOpen", false);
            }
            else if (other.GetComponent<Renderer>().material.name == yellowMaterial.name + " (Instance)")
            {
                yellowDoorAnimator.SetBool("isDoorOpen", false);
            }
            else if (other.GetComponent<Renderer>().material.name == redMaterial.name + " (Instance)")
            {
                foreach (Animator redAnimator in redDoorAnimator)
                {
                    redAnimator.SetBool("isDoorOpen", false);
                }
            }
        }
    }
}
