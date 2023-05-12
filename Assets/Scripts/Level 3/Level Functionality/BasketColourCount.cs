using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketColourCount : MonoBehaviour
{
    [SerializeField] int basketID;
    [SerializeField] SecretEndingManager secretEndingManagerScript;
    [SerializeField] Material keyMaterial;

    [SerializeField] Material rightIndicatorMaterial;
    [SerializeField] Material wrongIndicatorMaterial;
    [SerializeField] Renderer basketBaseRenderer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == keyMaterial.name + " (Instance)")
            {
                //secretEndingManagerScript.setBasketVerification(basketID, true);
                basketBaseRenderer.material = rightIndicatorMaterial;
            }
            else
            {
                basketBaseRenderer.material = wrongIndicatorMaterial;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == keyMaterial.name + " (Instance)")
            {
                //secretEndingManagerScript.setBasketVerification(basketID, false);
                basketBaseRenderer.material = wrongIndicatorMaterial;
            }
            else
            {
                basketBaseRenderer.material = wrongIndicatorMaterial;
            }
        }
    }
}
