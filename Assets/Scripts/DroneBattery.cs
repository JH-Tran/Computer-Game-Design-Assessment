using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DonreBattery : MonoBehaviour
{
    [SerializeField] DroneMovement droneMovement;
    [SerializeField] DroneCamera droneCamera;
    [SerializeField] private Image batteryInner;

    private float batteryMaxTime = 15f;
    [SerializeField] private float batteryTime;
    private float batteryCooldownTime = 5f;

    private bool isTimerOn;

    // Start is called before the first frame update
    void Start()
    {
        TimerReset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (isTimerOn)
        {
            if (batteryTime > 0)
            {
                batteryTime -= Time.deltaTime;
                batteryInner.fillAmount = batteryTime/batteryMaxTime;
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
        //batteryFillIndicator.transform.localScale = new Vector3(.1f, batteryFillIndicator.transform.localScale.y, batteryFillIndicator.transform.localScale.z);
        batteryInner.fillAmount = 1;
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
