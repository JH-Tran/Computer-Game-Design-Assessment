using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneAttachmentManager : MonoBehaviour
{
    [SerializeField] GameObject grabber;
    [SerializeField] GameObject ballMachine;
    [SerializeField] GameObject attachmentIcons;
    //For the tutorial level and level 1 to disable
    [SerializeField] bool enableBallMachine = true;
    private bool isClawActive = true;
    [SerializeField] GameObject swapFeatureImage;
    [SerializeField] GameObject swapItemGameObject;
    [SerializeField] Sprite ballIcon;
    [SerializeField] Sprite grabberIcon;
    [SerializeField] DroneMovement droneMovementScript;
    public bool isDroneEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        grabber.SetActive(true);
        ballMachine.SetActive(false);
        //If there is no ball machine feature enabled than player cannot swap features.
        if (enableBallMachine == false)
        {
            swapItemGameObject = GameObject.Find("SwapFeature");
            swapItemGameObject.SetActive(false);
        }
        else
        {
            swapFeatureImage = GameObject.Find("SwapFeatureImage");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) && isDroneEnabled == true)
        {
            if (enableBallMachine == true && isClawActive == true)
            {
                Debug.Log("Ball Machine Active");
                grabber.GetComponentInChildren<ClawGrabber>().ForceDropObject();
                grabber.SetActive(false);
                ballMachine.SetActive(true);
                ballMachine.GetComponent<BallMachine>().initaliseBallUI();
                isClawActive = false;
                swapFeatureImage.GetComponent<Image>().sprite = grabberIcon;
            }
            else if (enableBallMachine == true && isClawActive == false)
            {
                Debug.Log("Claw Active");
                grabber.SetActive(true);
                grabber.GetComponentInChildren<ClawGrabber>().initaliseClawUI();
                ballMachine.SetActive(false);
                isClawActive = true;
                if (enableBallMachine == true)
                {
                    swapFeatureImage.GetComponent<Image>().sprite = ballIcon;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && isClawActive == true && isDroneEnabled == true)
        {
            grabber.GetComponentInChildren<ClawGrabber>().useGrabber();
        }
        else if (Input.GetKeyDown(KeyCode.E) && isClawActive == false && enableBallMachine == true && isDroneEnabled == true)
        {
            ballMachine.GetComponent<BallMachine>().useBallMachine();
        }
    }
}
