using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneBattery : MonoBehaviour
{
    //Disable the drone when reaching 0 battery
    [SerializeField] private DroneMovement droneMovement;
    [SerializeField] private DroneCamera droneCamera;
    //Battery fill image
    [SerializeField] private Image batteryInner;
    //Black screen
    [SerializeField] private Image blackScreen;
    //Screen Saver UI Text
    [SerializeField] private GameObject screenSaverTexts;
    [SerializeField] private Text screenOffTimer;

    private ClawGrabber clawGrabber;
    //Using battery 25, 4
    private float batteryMaxTime = 25f;
    private float batteryTime;
    //Recharing Battery
    private float batteryCooldownTime = 4f;
    private float batterRechargeTime;
    private bool recharging = false;
    private bool isTabletVisible = false;
    //If the drone is not disabled
    public bool isTimerOn;

    void Start()
    {
        droneCamera = GameObject.Find("Drone1.0").GetComponent<DroneCamera>();
        droneMovement = GameObject.Find("Drone1.0").GetComponent<DroneMovement>();
        clawGrabber = GameObject.Find("ClawHitBox").GetComponent<ClawGrabber>();
        TimerReset();
        blackScreen.enabled = false;
        screenSaverTexts.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isTimerOn)
        {
            if (batteryTime > 0)
            {
                blackScreen.enabled = false;
                batteryTime -= Time.deltaTime;
                batteryInner.fillAmount = batteryTime/batteryMaxTime;
            }
            else
            {
                screenSaverTexts.SetActive(false);
                DisableDrone();
                clawGrabber.DropObject();
                clawGrabber.currentFeatureIndicator.color = Color.red;
            }
        }
        if (recharging == true)
        {
            if (batterRechargeTime > 0)
            {
                batterRechargeTime -= Time.deltaTime;
                if (batterRechargeTime < 0)
                {
                    batterRechargeTime = 0;
                }
                screenOffTimer.text = String.Format("{0:0.##}", batterRechargeTime);
            }
            else
            {
                batterRechargeTime = 0;
                TimerReset();
            }
        }

    }

    public void TimerReset()
    {
        //batteryFillIndicator.transform.localScale = new Vector3(.1f, batteryFillIndicator.transform.localScale.y, batteryFillIndicator.transform.localScale.z);
        recharging = false;
        batteryInner.fillAmount = 1;
        batteryTime = batteryMaxTime;
        isTimerOn = true;
        screenSaverTexts.SetActive(false);
        droneCamera.changeDroneState(isTimerOn);
        droneMovement.changeDroneState(isTimerOn);
    }
    //Disable drone base on a different cooldown that can be used by other scripts
    public void DisableDrone(float cooldown)
    {
        batteryInner.fillAmount = 0;
        batteryTime = 0;
        blackScreen.enabled = true;
        isTimerOn = false;
        droneCamera.changeDroneState(isTimerOn);
        droneMovement.changeDroneState(isTimerOn);
        rechargingDrone(cooldown);
    }
    //Origianl disable drone when the battery runs out.
    private void DisableDrone()
    {
        batteryTime = 0;
        blackScreen.enabled = true;
        isTimerOn = false;
        droneCamera.changeDroneState(isTimerOn);
        droneMovement.changeDroneState(isTimerOn);
        rechargingDrone(batteryCooldownTime);
    }
    public float getBattery()
    {
        return batteryTime;
    }
    //Start drone recharge timer; if the tablet is out than the screensavertext is shown.
    private void rechargingDrone(float delay)
    {
        if (isTabletVisible == false)
        {
            screenSaverTexts.SetActive(true);
        }
        batterRechargeTime = delay;
        recharging = true;
    }
    //Method for when tablet is being up or down to show the screen down time.
    public void isScreenSaverVisible(bool isTabletVisible)
    {
        if ((batterRechargeTime > 0) && isTabletVisible == true)
        {
            StartCoroutine(returnScreenSaver());
            this.isTabletVisible = true;
        }
        else if ((batterRechargeTime > 0) && isTabletVisible == false)
        {
            StopAllCoroutines();
            screenSaverTexts.SetActive(false);
            this.isTabletVisible = false;
        }
        else
        {
            StopAllCoroutines();
            screenSaverTexts.SetActive(false);
            this.isTabletVisible = true;
        }
    }
    
    IEnumerator returnScreenSaver()
    {
        yield return new WaitForSeconds(1);
        screenSaverTexts.SetActive(true);
    }
}
