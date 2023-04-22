using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourObjectPlate : MonoBehaviour
{
    //If the object has the same material as the door the door "opens".

    [SerializeField] private GameObject Door;
    [SerializeField] private Material keyMaterial;
    private bool isOpen = false;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (isOpen == true)
        {
            Door.SetActive(false);
        }
        else
        {
            Door.SetActive(true); 
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == keyMaterial.name + " (Instance)")
            {
                isOpen = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == keyMaterial.name + " (Instance)")
            {
                isOpen = false;
            }
        }
    }
}
