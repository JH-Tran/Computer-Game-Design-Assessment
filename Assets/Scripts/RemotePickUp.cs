using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemotePickUp : MonoBehaviour, IInteractable
{
    private GameObject playerObject;
    private bool pickedup = false;

    public void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        playerObject.GetComponent<Interactor>().pickedup = true;
    }
}
