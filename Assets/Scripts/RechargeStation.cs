using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeStation : MonoBehaviour
{
    [SerializeField] private Transform checkpoint;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            GameObject.Find("Drone Battery").GetComponent<DroneBattery>().rechargeDroneBatteryFromAny();
            GameObject.Find("Drone1.0").GetComponent<DroneMovement>().updateCheckpointPosition(checkpoint);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            GameObject.Find("Drone1.0").GetComponent<DroneMovement>().updateCheckpointPosition(checkpoint);
            GameObject.Find("Drone Battery").GetComponent<DroneBattery>().removeRechargeStationInfo();
        }
    }
}
