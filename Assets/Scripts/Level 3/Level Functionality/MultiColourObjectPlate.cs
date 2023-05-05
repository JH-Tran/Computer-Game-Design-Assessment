using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiColourObjectPlate : MonoBehaviour
{
    [SerializeField] private Material greyMaterial;
    [SerializeField] private Material yellowMaterial;
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material defaultMaterial;

    [SerializeField] private Animator greyDoorAnimator;
    [SerializeField] private Animator yellowDoorAnimator;
    [SerializeField] private Animator[] redDoorAnimator;

    [SerializeField] private GameObject[] basketBorder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == greyMaterial.name + " (Instance)")
            {
                greyDoorAnimator.SetBool("isDoorOpen", true);
                if (other.GetComponent<Renderer>().material.name != basketBorder[0].GetComponent<Renderer>().material.name + " (Instance)")
                {
                    foreach (GameObject i in basketBorder)
                    {
                        i.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;
                    }
                }
            }
            else if (other.GetComponent<Renderer>().material.name == yellowMaterial.name + " (Instance)")
            {
                yellowDoorAnimator.SetBool("isDoorOpen", true);
                if (other.GetComponent<Renderer>().material.name != basketBorder[0].GetComponent<Renderer>().material.name + " (Instance)")
                {
                    foreach (GameObject i in basketBorder)
                    {
                        i.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;
                    }
                }
            }
            else if (other.GetComponent<Renderer>().material.name == redMaterial.name + " (Instance)")
            {
                foreach(Animator redAnimator in redDoorAnimator)
                {
                    redAnimator.SetBool("isDoorOpen", true);

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
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == greyMaterial.name + " (Instance)")
            {
                greyDoorAnimator.SetBool("isDoorOpen", false);
                foreach (GameObject i in basketBorder)
                {
                    i.GetComponent<Renderer>().material = defaultMaterial;
                }
            }
            else if (other.GetComponent<Renderer>().material.name == yellowMaterial.name + " (Instance)")
            {
                yellowDoorAnimator.SetBool("isDoorOpen", false);
                foreach (GameObject i in basketBorder)
                {
                    i.GetComponent<Renderer>().material = defaultMaterial;
                }
            }
            else if (other.GetComponent<Renderer>().material.name == redMaterial.name + " (Instance)")
            {
                foreach (Animator redAnimator in redDoorAnimator)
                {
                    redAnimator.SetBool("isDoorOpen", false);
                    foreach (GameObject i in basketBorder)
                    {
                        i.GetComponent<Renderer>().material = defaultMaterial;
                    }
                }
            }
        }
    }
}
