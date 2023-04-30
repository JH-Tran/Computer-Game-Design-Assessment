using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttachmentManager : MonoBehaviour
{
    //Test script for features. Developers Only
    [SerializeField] GameObject claw;
    [SerializeField] GameObject ballMachine;
    [SerializeField] GameObject attachmentIcons;
    //For the tutorial level and level 1 to disable
    [SerializeField] bool enableBallMachine = true;
    private bool isClawActive = true;

    // Start is called before the first frame update
    void Start()
    {
        claw.SetActive(true);
        ballMachine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (enableBallMachine == true && isClawActive == true)
            {
                Debug.Log("Ball Machine Active");
                claw.GetComponentInChildren<ClawGrabber>().ForceDropObject();
                claw.SetActive(false);
                ballMachine.SetActive(true);
                ballMachine.GetComponent<BallMachine>().initaliseBallUI();
                isClawActive = false;
            }
            else
            {
                Debug.Log("Claw Active");
                claw.SetActive(true);
                claw.GetComponentInChildren<ClawGrabber>().initaliseClawUI();
                ballMachine.SetActive(false);
                isClawActive = true;
            }
        }
    }
}
