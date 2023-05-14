using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButton : MonoBehaviour, IInteractable
{
    public BlueDoor[] blueDoors;

    public Material[] material;
    public int x;
    Renderer rend;
    public bool isPressed = false;

    public AudioSource buttonSound;

    void Start()
    {
        x = 1;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

    void Update()
    {
        rend.sharedMaterial = material[x];
    }

    public void Interact()
    {
        buttonSound.Play();
        if (isPressed == false)
        {
            isPressed = true;
            x = 2;
        }

        else
        {
            isPressed = false;
            x = 1;
        }

        foreach (BlueDoor blueDoor in blueDoors)
        {
            if (blueDoor.isOpen == false)
            {
                blueDoor.isOpen = true;
                blueDoor.x = 2;
            }

            else
            {
                blueDoor.isOpen = false;
                blueDoor.x = 1;
            }            
        }
    }
}
