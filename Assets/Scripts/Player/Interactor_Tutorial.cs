using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IInteractableTut
{
    public void Interact();
}

public class Interactor_Tutorial : Interactor
{
    public Transform interactorSource;
    public GameObject drone;
    public GameObject remote;
    public GameObject pickupRemote;
    public bool pickedup = false;
    public GameObject pedestal;
    public GameObject eToInteract2;
    public GameObject raiseRemote;
    public GameObject trigger5;
    private Animator pedestalAnim;
    [SerializeField] GameObject spotlight;
    [SerializeField] FirstPersonController fpController;

    public GameObject playerButton;
    public Animator playerButtonAnim;
    public PlayerButtonPressed playerButtonPressed;

    //Change Button sign when interacted
    [SerializeField] GameObject pressButtonSign;
    [SerializeField] GameObject playerToDroneSign;
    [SerializeField] GameObject droneToPersonTrigger;
    [SerializeField] GameObject droneToPersonIcon;
    [SerializeField] GameObject tutIcon;

    //PauseMenu
    [SerializeField] PauseMenu pauseMenuScript;

    void Start()
    {
        pedestalAnim = pedestal.GetComponent<Animator>();
        playerButtonAnim = playerButton.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInteracting == true)
        {
            RaycastHit hitInfo;
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            bool hit = Physics.Raycast(r, out hitInfo, interactRange);
            if (hit)
            {
                if (hitInfo.transform.gameObject.tag == "Remote")
                {
                    pickedup = true;
                    //Removes E
                    GameObject.FindGameObjectWithTag("Part1").SetActive(false);
                    pedestalAnim.SetBool("isEmpty", true);
                    spotlight.SetActive(false);
                    fpController.isPlayerCameraLocked(true);
                }

                if (hitInfo.transform.gameObject == playerButton)
                {
                    if (playerButtonPressed.isOpen == false)
                    {
                        playerButtonPressed.isOpen = true;
                        playerButtonPressed.x = 2;
                        playerButtonPressed.door2Anim.SetBool("isOpen", true);
                        playerButtonPressed.isOpen = true;
                        //Change player room sign to press the button
                        pressButtonSign.SetActive(false);
                        playerToDroneSign.SetActive(true);
                        //Disable the drone to person sign 
                        droneToPersonTrigger.SetActive(false);
                        droneToPersonIcon.SetActive(false);
                        tutIcon.SetActive(false);
                    }

                    else if (playerButtonPressed.isOpen == true)
                    {
                        playerButtonPressed.isOpen = false;
                        playerButtonPressed.x = 1;
                        playerButtonPressed.door2Anim.SetBool("isOpen", false);
                        playerButtonPressed.isOpen = false;
                        //Change player room sign to show player to drone sign
                        pressButtonSign.SetActive(true);
                        playerToDroneSign.SetActive(false);
                        //Enables the drone to person sign
                        droneToPersonTrigger.SetActive(true);
                    }
                }
            }

            if (pickedup == true)
            {
                drone.SetActive(true);
                remote.SetActive(true);
                if (pickupRemote.activeSelf == true)
                {
                    GameObject.FindWithTag("Remote").SetActive(false);
                }
                pauseMenuScript.droneFound();

            }
        }
    }
}
