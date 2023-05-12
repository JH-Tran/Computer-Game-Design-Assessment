using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour, IInteractable
{
    public RedDoor[] redDoors;

    public Material[] material;
    public int x;
    Renderer rend;
    public bool isPressed = false;

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

        foreach (RedDoor redDoor in redDoors)
        {
            if (redDoor.isOpen == false)
            {
                redDoor.isOpen = true;
                redDoor.x = 2;
            }

            else
            {
                redDoor.isOpen = false;
                redDoor.x = 1;
            }            
        }
    }
}
