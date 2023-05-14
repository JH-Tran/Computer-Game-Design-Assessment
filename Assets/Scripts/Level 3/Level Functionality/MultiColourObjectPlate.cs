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

    public AudioSource basketIn;
    public AudioSource doorSound;
    private bool soundIsPlayed = false;

    private void OnTriggerStay(Collider other)
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
                    if (soundIsPlayed == false)
                    {
                        basketIn.Play();
                        doorSound.Play();
                        soundIsPlayed = true;
                    }
                }
            }
            else if (other.GetComponent<Renderer>().material.name == yellowMaterial.name + " (Instance)")
            {
                if (yellowDoorAnimator != null)
                {
                    yellowDoorAnimator.SetBool("isDoorOpen", true);
                }
                if (other.GetComponent<Renderer>().material.name != basketBorder[0].GetComponent<Renderer>().material.name + " (Instance)")
                {
                    foreach (GameObject i in basketBorder)
                    {
                        i.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;
                    }
                    if (soundIsPlayed == false)
                    {
                        basketIn.Play();
                        doorSound.Play();
                        soundIsPlayed = true;
                    }
                }
            }
            else if (other.GetComponent<Renderer>().material.name == redMaterial.name + " (Instance)")
            {
                if (redDoorAnimator != null)
                {
                    foreach (Animator redAnimator in redDoorAnimator)
                    {
                        redAnimator.SetBool("isDoorOpen", true);
                    }
                    if (soundIsPlayed == false)
                    {
                        basketIn.Play();
                        doorSound.Play();
                        soundIsPlayed = true;
                    }
                }
                if (other.GetComponent<Renderer>().material.name != basketBorder[0].GetComponent<Renderer>().material.name + " (Instance)")
                {
                    foreach (GameObject i in basketBorder)
                    {
                        i.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;
                    }
                    if (soundIsPlayed == false)
                    {
                        basketIn.Play();
                        doorSound.Play();
                        soundIsPlayed = true;
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
                soundIsPlayed = false;
            }
            else if (other.GetComponent<Renderer>().material.name == yellowMaterial.name + " (Instance)")
            {
                yellowDoorAnimator.SetBool("isDoorOpen", false);
                foreach (GameObject i in basketBorder)
                {
                    i.GetComponent<Renderer>().material = defaultMaterial;
                }
                soundIsPlayed = false;
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
                if (soundIsPlayed == true)
                {
                    doorSound.Play();
                    soundIsPlayed = false;
                }
            }
        }
    }
}
