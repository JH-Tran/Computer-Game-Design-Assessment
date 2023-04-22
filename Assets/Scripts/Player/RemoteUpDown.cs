using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteUpDown : MonoBehaviour
{
    [SerializeField] FirstPersonController playerCam;
    [SerializeField] DroneBattery droneBattery;

    private Animator anim;
    [SerializeField] private bool lookingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        droneBattery = GetComponentInChildren<DroneBattery>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(lookingUp == true)
            {
                anim.SetBool("isHolding", false);
                lookingUp = false;
                droneBattery.isScreenSaverVisible(lookingUp);
            }
            else
            {
                anim.SetBool("isHolding", true);
                lookingUp = true;
                droneBattery.isScreenSaverVisible(lookingUp);
            }
            playerCam.PlayerCameraLock(lookingUp);
        }
    }
}
