using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawGrabber : MonoBehaviour
{
    [SerializeField] private BoxCollider clawCollider;
    [SerializeField] private Transform clawInitalPosition;

    private bool isObjectGrab;
    private bool isObstacle;

    private void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Object"))
        {
            other.transform.parent = gameObject.transform;
            Destroy(other.GetComponent<Rigidbody>());
        }
    }

    public void ClawMovement()
    {

    }
}
