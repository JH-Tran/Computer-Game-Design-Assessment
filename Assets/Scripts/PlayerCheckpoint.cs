using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            other.GetComponentInParent<DroneMovement>().updateCheckpointPosition(gameObject.transform);
        }
    }
}
