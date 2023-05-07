using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourDoorObjectPlate : MonoBehaviour
{
    //If the object has the same material as the door the door "opens".
    [SerializeField] private Material keyMaterial;
    [SerializeField] private Animator doorAnimator;
    //BasketColour
    [SerializeField] private GameObject[] basketBorder;
    [SerializeField] private Material defaultMaterial;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == keyMaterial.name + " (Instance)")
            {
                doorAnimator.SetBool("isDoorOpen", true);
            }
            if (other.GetComponent<Renderer>().material.name != basketBorder[0].GetComponent<Renderer>().material.name + " (Instance)")
            {
                foreach (GameObject i in basketBorder)
                {
                    i.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;
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
            }
            foreach (GameObject i in basketBorder)
            {
                i.GetComponent<Renderer>().material = defaultMaterial;
            }
        }
    }
}
