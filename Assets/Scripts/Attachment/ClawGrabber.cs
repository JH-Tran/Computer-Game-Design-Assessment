using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClawGrabber : MonoBehaviour
{
    [SerializeField] private BoxCollider clawCollider;
    public Image grabIndicator;
    public DroneBattery droneBattery;

    public bool isGrabbingObject = false;
    public bool isObjectHold = false;
    private float autoOffGrab = 2;
    private List<GameObject> objectGrabbed = new List<GameObject>();


    private void Start()
    {
        grabIndicator.color = Color.red;
    }

    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.F))
        {
            if (droneBattery.isTimerOn == true)
            {
                if (isGrabbingObject == false)
                {
                    grabIndicator.color = Color.yellow;
                    isGrabbingObject = true;
                    StartCoroutine(autoTurnOffGrab());
                }
                else if (isGrabbingObject == true && isObjectHold == true)
                {
                    DropObject();
                    grabIndicator.color = Color.red;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.name);
        if (other.CompareTag("Object"))
        {
            if (isGrabbingObject == true && isObjectHold == false)
            {
                grabIndicator.color = Color.green;
                other.transform.parent = gameObject.transform;
                objectGrabbed.Add(other.gameObject);
                isObjectHold = true;
                Destroy(other.GetComponent<Rigidbody>());
            }
        }
    }

    IEnumerator autoTurnOffGrab()
    {
        yield return new WaitForSeconds(autoOffGrab);
        if (isGrabbingObject == true && isObjectHold == false)
        {
            isGrabbingObject = false;
            grabIndicator.color = Color.red;
        }
    }

    public void DropObject()
    {
        if (objectGrabbed.Count > 0 && isObjectHold == true)
        {
            for (int i = 0; i < objectGrabbed.Count; i++)
            {
                if (objectGrabbed[i].GetComponent<Rigidbody>() == null)
                {
                    objectGrabbed[i].gameObject.AddComponent<Rigidbody>();
                }
                objectGrabbed[i].transform.parent = null;
            }
            objectGrabbed.Clear();
            isObjectHold = false;
        }
        isGrabbingObject = false;
    }

    public bool getGrabbingObject()
    {
        return isGrabbingObject;
    }
}
