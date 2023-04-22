using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteUpDown : MonoBehaviour
{
    [SerializeField] FirstPersonController playerCam;
    [SerializeField] DroneBattery droneBattery;

    private Animator anim;
    [SerializeField] private bool lookingAtTablet = true;

    // Start is called before the first frame update
    void Start()
    {
        droneBattery = GetComponentInChildren<DroneBattery>();
        anim = GetComponent<Animator>();
        droneBattery.setPlayerLookingAtTablet(lookingAtTablet);
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
            }
            else
            {
                anim.SetBool("isHolding", true);
                lookingAtTablet = true;
                droneBattery.setPlayerLookingAtTablet(lookingAtTablet);
            }
            playerCam.PlayerCameraLock(lookingAtTablet);
        }
    }
}
