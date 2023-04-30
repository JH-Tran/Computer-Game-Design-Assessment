using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointPlatform : MonoBehaviour
{

    void FixedUpdate()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            GameObject.Find("Drone Battery").GetComponent<DroneBattery>().rechargeDroneBatteryFromAny();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            GameObject.Find("Drone Battery").GetComponent<DroneBattery>().removeRechargeStationInfo();
        }
    }
}
