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
    [SerializeField] private Text screenSaverExtraInformationText;
    [SerializeField] private String[] flavourText;
    //Recharge Station Reminder
    [SerializeField] private GameObject rechargeStationInfoCanvas;
    //Low Battery Indicator
    [SerializeField] private Animator lowBatteryAnim;


    private ClawGrabber clawGrabber;
    private DroneAttachmentManager droneAttachmentManager;
    //Using battery to move drone around. 90 max time and 3 cooldown (SUBJECT TO CHANGE)
    private float batteryMaxTime = 90;
    [SerializeField] private float batteryTime;
    //Recharing Battery
    private float batteryCooldownTime = 3f;
    private float batteryRechargeTime;
    private bool isBatteryRechargeFromZero = false;
    private bool isLookingAtTablet;

    //If the drone is not disabled
    public bool isTimerOn;
    //Recharing battery from any percentage
    private float rechargeSpeed = 50;

    void Start()
    {
        droneCamera = GameObject.Find("Drone1.0").GetComponent<DroneCamera>();
        droneMovement = GameObject.Find("Drone1.0").GetComponent<DroneMovement>();
        clawGrabber = GameObject.Find("ClawHitBox").GetComponent<ClawGrabber>();
        droneAttachmentManager = GameObject.Find("DroneAttachments").GetComponent<DroneAttachmentManager>();
        TimerReset();
        blackScreen.enabled = false;
        screenSaverTexts.SetActive(false);
        rechargeStationInfoCanvas.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isTimerOn)
        {
            useDrone();
        }
        if (isBatteryRechargeFromZero == true)
        {
            rechargeBatteryFromZero();
        }

    }
    private void useDrone()
    {
        if (batteryTime > 0)
        {
            ChangeDroneMovement(isLookingAtTablet);
            blackScreen.enabled = false;
            if (droneMovement.getDroneVelocity() > 0.1f)
            {
                batteryTime -= Time.deltaTime;
                batteryInner.fillAmount = batteryTime / batteryMaxTime;
            }
            if ((batteryTime/batteryMaxTime) <= 0.2f && (batteryTime / batteryMaxTime) > 0)
            {
                lowBatteryAnim.SetBool("isBatteryLow", true);
            }
        }
        else
        {
            screenSaverTexts.SetActive(false);
            DisableDrone();
            droneMovement.changeDroneGravity(true);
            if (droneAttachmentManager.getClawActive())
            {
                clawGrabber.ForceDropObject();
            }
            droneMovement.resetToCheckpoint();
        }
    }
    private void rechargeBatteryFromZero()
    {
        //Debug.Log(batteryRechargeTime);
        if (batteryRechargeTime > 0)
        {
            batteryRechargeTime -= Time.deltaTime;
            if (batteryRechargeTime < 0)
            {
                batteryRechargeTime = 0;
            }
            isScreenSaverVisible();
            lowBatteryAnim.SetBool("isBatteryLow", false);
        }
        else
        {
            batteryRechargeTime = 0;
            removeScreenSaver();
            TimerReset();
        }
    }

    public void TimerReset()
    {
        //batteryFillIndicator.transform.localScale = new Vector3(.1f, batteryFillIndicator.transform.localScale.y, batteryFillIndicator.transform.localScale.z);
        isBatteryRechargeFromZero = false;
        batteryInner.fillAmount = 1;
        batteryTime = batteryMaxTime;
        isTimerOn = true;
        screenSaverTexts.SetActive(false);
        droneCamera.changeDroneState(isTimerOn);
        droneMovement.changeDroneState(isTimerOn);
        droneMovement.changeDroneGravity(false);
        lowBatteryAnim.SetBool("isBatteryLow", false);
    }
    //Disable drone base on a different cooldown that can be used by other scripts
    public void DisableDrone(float cooldown)
    {
        batteryInner.fillAmount = 0;
        batteryTime = 0;
        lowBatteryAnim.SetBool("isBatteryLow", false);
        blackScreen.enabled = true;
        isTimerOn = false;
        if (droneAttachmentManager.getClawActive())
        {
            clawGrabber.ForceDropObject();
        }
        droneCamera.changeDroneState(isTimerOn);
        droneMovement.changeDroneState(isTimerOn);
        screenSaverExtraInformationText.text = flavourText[1];
        screenSaverDroneTime(cooldown);
    }
    //Disable drone when the battery runs out set amount.
    private void DisableDrone()
    {
        batteryTime = 0;
        lowBatteryAnim.SetBool("isBatteryLow", false);
        blackScreen.enabled = true;
        isTimerOn = false;
        droneCamera.changeDroneState(isTimerOn);
        droneMovement.changeDroneState(isTimerOn);
        screenSaverExtraInformationText.text = flavourText[0];
        screenSaverDroneTime(batteryCooldownTime);
    }
    //Stop Movement
    public void ChangeDroneMovement(bool droneState)
    {
        droneCamera.changeDroneState(droneState);
        droneMovement.changeDroneState(droneState);
    }
    //Start drone recharge timer
    private void screenSaverDroneTime(float delay)
    {
        if (isLookingAtTablet == true)
        {
            screenSaverTexts.SetActive(true);
        }
        batteryRechargeTime = delay;
        isBatteryRechargeFromZero = true;
    }
    //Method for when tablet is being up or down to show the screen down time.
    public void isScreenSaverVisible()
    {
        if ((batteryRechargeTime > 0) && isLookingAtTablet == true)
        {
            StartCoroutine(returnScreenSaver());
        }
        else if ((batteryRechargeTime > 0) && isLookingAtTablet == false)
        {
            StopAllCoroutines();
            screenSaverTexts.SetActive(false);
        }
    }
    public void rechargeDroneBatteryFromAny()
    {
        if (rechargeStationInfoCanvas != null)
        {
            rechargeStationInfoCanvas.SetActive(true);
        }

        if (isLookingAtTablet == false && isBatteryRechargeFromZero == false)
        {
            if (rechargeStationInfoCanvas != null)
            {
                Destroy(rechargeStationInfoCanvas);
            }
            isTimerOn = false;
            if (batteryTime >= batteryMaxTime)
            {
                batteryTime = batteryMaxTime;
            }
            else
            {
                batteryTime += rechargeSpeed * Time.deltaTime;
            }
            batteryInner.fillAmount = batteryTime / batteryMaxTime;
            lowBatteryAnim.SetBool("isBatteryLow", false);
        }
        else if (isLookingAtTablet == true && batteryRechargeTime <= 0 && isBatteryRechargeFromZero == false)
        {
            isTimerOn = true;
        }
    }
    private void removeScreenSaver()
    {
        StopAllCoroutines();
        screenSaverTexts.SetActive(false);
    }
    public void removeRechargeStationInfo()
    {
        if (rechargeStationInfoCanvas != null)
        {
            rechargeStationInfoCanvas.SetActive(false);
        }
    }
    public void setPlayerLookingAtTablet(bool lookingAtTablet)
    {
        this.isLookingAtTablet = lookingAtTablet;
    }
    IEnumerator returnScreenSaver()
    {
        yield return new WaitForSeconds(1);
        screenSaverTexts.SetActive(true);
    }
}
