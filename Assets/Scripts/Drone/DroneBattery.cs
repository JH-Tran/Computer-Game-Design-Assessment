using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBattery : MonoBehaviour
{
    [SerializeField] GameObject batteryFillIndicator;
    [SerializeField] DroneMovement droneMovement;
    [SerializeField] DroneCamera droneCamera;

    //Timers are in seconds
    private float batteryMaxTime = 120f;
    private float batteryTime;
    private float batteryCooldownTime = 5f;

    private bool isTimerOn;

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
                StartCoroutine(activeDrone(batteryCooldownTime));
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

    IEnumerator activeDrone(float delay)
    {
        yield return new WaitForSeconds(delay);
        TimerReset();
    }
}
