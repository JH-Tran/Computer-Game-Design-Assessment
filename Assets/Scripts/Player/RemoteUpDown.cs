using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
=======
using UnityEngine.UI;
>>>>>>> origin

public class RemoteUpDown : MonoBehaviour
{
    [SerializeField] FirstPersonController playerCam;
<<<<<<< HEAD

    private Animator anim;
    [SerializeField] private bool lookingUp = true;
=======
    [SerializeField] DroneBattery droneBattery;

    private Animator anim;
    [SerializeField] private bool lookingAtTablet = true;

    [SerializeField] GameObject playerStateObject;
    [SerializeField] Sprite droneStateIcon;
    [SerializeField] Sprite playerStateIcon;

    [SerializeField] DroneAttachmentManager droneAttachmentManagerScript;
    [SerializeField] Interactor interactor;
>>>>>>> origin

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        anim = GetComponent<Animator>();
=======
        droneBattery = GetComponentInChildren<DroneBattery>();
        anim = GetComponent<Animator>();
        droneBattery.setPlayerLookingAtTablet(lookingAtTablet);
        playerStateObject.GetComponent<Image>().sprite = droneStateIcon;
        droneAttachmentManagerScript = GameObject.Find("DroneAttachments").GetComponent<DroneAttachmentManager>();
        interactor = GetComponentInParent<Interactor>();
>>>>>>> origin
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(lookingUp == true)
            {
                anim.SetBool("isHolding", false);
                lookingUp = false;
=======
        if(Input.GetKeyDown(KeyCode.Tab) && Time.timeScale != 0)
        {
            if(lookingAtTablet == true)
            {
                anim.SetBool("isHolding", false);
                lookingAtTablet = false;
                droneBattery.setPlayerLookingAtTablet(lookingAtTablet);
                playerStateObject.GetComponent<Image>().sprite = playerStateIcon;

                interactor.setPlayerInteracting(true);
                droneAttachmentManagerScript.isDroneEnabled = false;
>>>>>>> origin
            }
            else
            {
                anim.SetBool("isHolding", true);
<<<<<<< HEAD
                lookingUp = true;
            }
            playerCam.PlayerCameraLock(lookingUp);
=======
                lookingAtTablet = true;
                droneBattery.setPlayerLookingAtTablet(lookingAtTablet);
                playerStateObject.GetComponent<Image>().sprite = droneStateIcon;

                interactor.setPlayerInteracting(false);
                droneAttachmentManagerScript.isDroneEnabled = true;
            }
            playerCam.isPlayerCameraLocked(lookingAtTablet);
>>>>>>> origin
        }
    }
}
