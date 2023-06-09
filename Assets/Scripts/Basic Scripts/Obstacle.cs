using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float droneDisableTime = 2f;
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Drone")) {
            GameObject.Find("Drone Battery").GetComponent<DroneBattery>().DisableDrone(droneDisableTime);
            other.gameObject.GetComponentInParent<DroneMovement>().resetToCheckpoint();
        }
        else if (other.CompareTag("Object"))
        {
            other.GetComponent<ObjectOrigin>().setOriginPosition();
        }
    }
}
