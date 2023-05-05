using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoteUpDown : MonoBehaviour
{
    [SerializeField] FirstPersonController playerCam;
    [SerializeField] DroneBattery droneBattery;

    private Animator anim;
    [SerializeField] private bool lookingAtTablet = true;

    [SerializeField] GameObject playerStateObject;
    [SerializeField] Sprite droneStateIcon;
    [SerializeField] Sprite playerStateIcon;

    // Start is called before the first frame update
    void Start()
    {
        droneBattery = GetComponentInChildren<DroneBattery>();
        anim = GetComponent<Animator>();
        droneBattery.setPlayerLookingAtTablet(lookingAtTablet);
        playerStateObject.GetComponent<Image>().sprite = droneStateIcon;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(lookingAtTablet == true)
            {
                anim.SetBool("isHolding", false);
                lookingAtTablet = false;
                droneBattery.setPlayerLookingAtTablet(lookingAtTablet);
                playerStateObject.GetComponent<Image>().sprite = playerStateIcon;
            }
            else
            {
                anim.SetBool("isHolding", true);
                lookingAtTablet = true;
                droneBattery.setPlayerLookingAtTablet(lookingAtTablet);
                playerStateObject.GetComponent<Image>().sprite = droneStateIcon;
            }
            playerCam.isPlayerCameraLocked(lookingAtTablet);
        }
    }
}
