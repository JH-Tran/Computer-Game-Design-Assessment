using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClawGrabber : MonoBehaviour
{
    [SerializeField] private BoxCollider clawCollider;
    public Image currentFeatureIndicator;
    [SerializeField] private Sprite clawIndicatorImage;
    public DroneBattery droneBattery;

    public bool isGrabbingObject = false;
    public bool isObjectHold = false;
    private float autoOffGrab = 2;
    private List<GameObject> objectGrabbed = new List<GameObject>();

    private void Start()
    {
        clawCollider = gameObject.GetComponent<BoxCollider>();
        currentFeatureIndicator = GameObject.Find("FeatureIcon").GetComponent<Image>();
        droneBattery = GameObject.Find("Drone Battery").GetComponent<DroneBattery>();
        currentFeatureIndicator.color = Color.red;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (droneBattery.isTimerOn == true)
            {
                if (isGrabbingObject == false)
                {
                    isGrabbingObject = true;
                    currentFeatureIndicator.color = Color.yellow;
                    StartCoroutine(autoTurnOffGrab());
                }
                else if (isGrabbingObject == true && isObjectHold == true)
                {
                    DropObject();
                    currentFeatureIndicator.color = Color.red;
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
                currentFeatureIndicator.color = Color.green;
                other.transform.parent = gameObject.transform;
                objectGrabbed.Add(other.gameObject);
                isObjectHold = true;
                Destroy(other.GetComponent<Rigidbody>());
            }
            else if (isGrabbingObject == false && isObjectHold == false)
            {
                currentFeatureIndicator.color = Color.yellow;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.name);
        if (other.CompareTag("Object"))
        {
            if (isGrabbingObject == false && isObjectHold == false)
            {
                currentFeatureIndicator.color = Color.red;
            }
        }
    }

    IEnumerator autoTurnOffGrab()
    {
        yield return new WaitForSeconds(autoOffGrab);
        if (isGrabbingObject == true && isObjectHold == false)
        {
            isGrabbingObject = false;
            currentFeatureIndicator.color = Color.red;
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

    public void ForceDropObject()
    {
        if (objectGrabbed.Count > 0)
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
        currentFeatureIndicator.color = Color.red;
    }
    public void initaliseClawUI()
    {
        currentFeatureIndicator.sprite = clawIndicatorImage;
        currentFeatureIndicator.fillAmount = 1;
        currentFeatureIndicator.color = Color.red;
    }

    public bool getGrabbingObject()
    {
        return isGrabbingObject;
    }
}
