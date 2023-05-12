using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangePuzzleTrigger : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject lightsOff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            other.GetComponentInParent<DroneMovement>().updateCheckpointPosition(gameObject.transform);
            puzzle.SetActive(true);
            lightsOff.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            puzzle.SetActive(false);
            lightsOff.SetActive(true);
        }
    }
}
