using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange = 10;
    public GameObject drone;
    public GameObject remote;
    public bool pickedup = false;

    [SerializeField] private bool isBlueActive, isRedActive, isGreenActive;


    public void Start()
    {
        isBlueActive = false;
        isRedActive = false;
        isGreenActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange)) {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObject))
                {
                    interactObject.Interact();
                }
            }
        }
        PickUpRemote();
    }

    public bool PickUpRemote()
    {
        if (pickedup == true)
        {
            drone.SetActive(true);
            remote.SetActive(true);
            return true;
        }
        return false;
    }

    public void SetOneActivateColour(string colour)
    {

        if (colour.Equals("blue"))
        {
            isBlueActive = true;
            isRedActive = false;
            isGreenActive = false;
        }
        else if (colour.Equals("red"))
        {
            isBlueActive = false;
            isRedActive = true;
            isGreenActive = false;
        }
        else if (colour.Equals("green"))
        {
            isBlueActive = false;
            isRedActive = false;
            isGreenActive = true;
        }
    }

}
