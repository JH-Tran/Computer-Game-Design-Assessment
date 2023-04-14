using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtonBlue : MonoBehaviour, IInteractable
{
    private GameObject playerObject;
    public void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    public void Interact()
    {
        playerObject.GetComponent<Interactor>().SetOneActivateColour("blue");
    }
}
