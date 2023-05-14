using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourDoorObjectPlate : MonoBehaviour
{
    //If the object has the same material as the door the door "opens".
    public Material keyMaterial;
    [SerializeField] private Animator doorAnimator;
    //BasketColour
    [SerializeField] private GameObject[] basketBorder;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private bool isBasketChangingColour = true;
    public AudioSource basketIn;
    public bool isAudioPlayed = false;
    public AudioSource openDoor;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.GetComponent<Renderer>().material.name == keyMaterial.name + " (Instance)")
            {
                doorAnimator.SetBool("isDoorOpen", true);
                if (isAudioPlayed == false)
                {
                    openDoor.Play();
                }
            }
            if (isBasketChangingColour == true)
            {
                if (other.GetComponent<Renderer>().material.name != basketBorder[0].GetComponent<Renderer>().material.name + " (Instance)")
                {
                    foreach (GameObject i in basketBorder)
                    {
                        i.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;
                    }
                }
                if (isAudioPlayed == false)
                {
                    basketIn.Play();
                    isAudioPlayed = true;
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
                isAudioPlayed = false;
            }
            foreach (GameObject i in basketBorder)
            {
                i.GetComponent<Renderer>().material = defaultMaterial;
            }
        }
        isAudioPlayed = false;
    }
}
