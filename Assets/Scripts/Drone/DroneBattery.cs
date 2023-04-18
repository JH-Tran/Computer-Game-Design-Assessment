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
    //Screen Saver
    [SerializeField] private GameObject screenSaverTexts;
    [SerializeField] private Text screenOffTimer;

    private ClawGrabber clawGrabber;
    //Using battery 25, 4
    private float batteryMaxTime = 2f;
    private float batteryTime;
    //Recharing Battery
    private float batteryCooldownTime = 10f;
    private float batterRechargeTime;
    private bool recharging = false;
    private bool isUsingTablet = false;
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
                screenOffTimer.text = String.Format("{0:0.##}", batterRechargeTime);
            }
            else
            {
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
    private void rechargingDrone(float delay)
    {
        if (isUsingTablet == false)
        {
            screenSaverTexts.SetActive(true);
        }
        batterRechargeTime = delay;
        recharging = true;
    }
    public void isScreenSaverVisible(bool isVisible)
    {
        if ((batterRechargeTime > 0) && isVisible == true)
        {
            StartCoroutine(returnScreenSaver());
            isUsingTablet = false;
        }
        else if ((batterRechargeTime <= 0) && isVisible == true)
        {
            screenSaverTexts.SetActive(false);
            isUsingTablet = false;
        }
        else
        {
            screenSaverTexts.SetActive(isVisible);
            isUsingTablet = true;
        }
    }
    
    IEnumerator returnScreenSaver()
    {
        yield return new WaitForSeconds(1);
        screenSaverTexts.SetActive(true);
    }
}
