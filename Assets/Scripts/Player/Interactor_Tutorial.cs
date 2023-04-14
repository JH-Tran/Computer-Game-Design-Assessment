using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractableTut
{
    public void Interact();
}

public class Interactor_Tutorial : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange = 10;
    public GameObject drone;
    public GameObject remote;
    public GameObject pickupRemote;
    public bool pickedup = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit hitInfo;
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            bool hit = Physics.Raycast(r, out hitInfo, interactRange);
            if (hit)
            {
                if (hitInfo.transform.gameObject.tag == "Object")
                {
                    pickedup = true;
                }
            }
        }

        if (pickedup == true)
        {
            drone.SetActive(true);
            remote.SetActive(true);
            if (pickupRemote.activeSelf == true)
            {
                GameObject.FindWithTag("Object").SetActive(false);
            }

        }
    }
}
