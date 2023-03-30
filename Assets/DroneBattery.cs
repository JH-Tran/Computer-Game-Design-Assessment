using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBattery : MonoBehaviour
{
    [SerializeField] GameObject batteryFillIndicator;
    [SerializeField] DroneMovement droneMovement;
    [SerializeField] DroneCamera droneCamera;

    //Max battery is in seconds
    [SerializeField] private float batteryMaxTime = 10f;
    [SerializeField] private float batteryTime;
    [SerializeField] private bool isTimerOn;

    void Start()
    {
        TimerReset();
    }

    void FixedUpdate()
    {
        if (isTimerOn)
        {
            if (batteryTime > 0)
            {
                batteryTime -= Time.deltaTime;
                batteryFillIndicator.transform.localScale = new Vector3 (batteryTime/batteryMaxTime, batteryFillIndicator.transform.localScale.y, batteryFillIndicator.transform.localScale.z);
            }
            else
            {
                batteryTime = 0;
                isTimerOn = false;
                droneCamera.changeDroneState(isTimerOn);
                droneMovement.changeDroneState(isTimerOn);
            }
        }
    }

    public void TimerReset()
    {
        batteryFillIndicator.transform.localScale = new Vector3(.1f, batteryFillIndicator.transform.localScale.y, batteryFillIndicator.transform.localScale.z);
        batteryTime = batteryMaxTime;
        isTimerOn = true;
        droneCamera.changeDroneState(isTimerOn);
        droneMovement.changeDroneState(isTimerOn);
    }
}
