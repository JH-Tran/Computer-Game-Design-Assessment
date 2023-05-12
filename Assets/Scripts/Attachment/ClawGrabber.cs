using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClawGrabber : MonoBehaviour
{
    [SerializeField] private BoxCollider clawCollider;
    public Image currentFeatureIndicator;
    [SerializeField] private Sprite initalMagnetSprite;
    [SerializeField] private Sprite magnetObjectSprite;
    [SerializeField] private Sprite activeMagnetNoObjectSprite;
    [SerializeField] private Sprite activeMagnetObjectSprite;

    public DroneBattery droneBattery;

    public bool isMagnetActive = false;
    public bool isMagnetHoldingObject = false;
    public bool isObjectFound = false;
    private float autoOffGrab = 2;
    private List<GameObject> objectGrabbed = new List<GameObject>();

    private void Start()
    {
        clawCollider = gameObject.GetComponent<BoxCollider>();
<<<<<<< HEAD
        grabIndicator = GameObject.Find("GrabIcon").GetComponent<Image>();
        droneBattery = GameObject.Find("Drone Battery").GetComponent<DroneBattery>();
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
=======
        currentFeatureIndicator = GameObject.Find("FeatureIcon").GetComponent<Image>();
        droneBattery = GameObject.Find("Drone Battery").GetComponent<DroneBattery>();
        updateDroneGrabberUI();
        currentFeatureIndicator.color = Color.red;
>>>>>>> origin
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.name);
        if (other.CompareTag("Object"))
        {
            isObjectFound = true;
            if (isMagnetActive == true && isMagnetHoldingObject == false)
            {
                currentFeatureIndicator.color = Color.green;
                other.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
                other.transform.parent = gameObject.transform;
                objectGrabbed.Add(other.gameObject);
                isMagnetHoldingObject = true;
                Destroy(other.GetComponent<Rigidbody>());
                updateDroneGrabberUI();
            }
            else if (isMagnetActive == false && isMagnetHoldingObject == false)
            {
                updateDroneGrabberUI();
                currentFeatureIndicator.color = Color.yellow;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.name);
        if (other.CompareTag("Object"))
        {
            isObjectFound = false;
            if (isMagnetActive == false && isMagnetHoldingObject == false)
            {
                updateDroneGrabberUI();
                currentFeatureIndicator.color = Color.red;
            }
        }
    }

    IEnumerator autoTurnOffGrab()
    {
        yield return new WaitForSeconds(autoOffGrab);
        if (isMagnetActive == true && isMagnetHoldingObject == false)
        {
            isMagnetActive = false;
            updateDroneGrabberUI();
            currentFeatureIndicator.color = Color.red;
        }
    }

    public void DropObject()
    {
        if (objectGrabbed.Count > 0 && isMagnetHoldingObject == true)
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
            isMagnetHoldingObject = false;
        }
        isMagnetActive = false;
        updateDroneGrabberUI();
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
            isMagnetHoldingObject = false;
            isObjectFound = false;
        }
        isMagnetActive = false;
        updateDroneGrabberUI();
        currentFeatureIndicator.color = Color.red;
    }
    public void initaliseClawUI()
    {
        currentFeatureIndicator.sprite = initalMagnetSprite;
        currentFeatureIndicator.fillAmount = 1;
        updateDroneGrabberUI();
        currentFeatureIndicator.color = Color.red;
    }

    public bool getGrabbingObject()
    {
        return isMagnetActive;
    }

    public void useGrabber()
    {
        if (droneBattery.isTimerOn == true)
        {
            if (isMagnetActive == false)
            {
                isMagnetActive = true;
                updateDroneGrabberUI();
                currentFeatureIndicator.color = Color.yellow;
                StartCoroutine(autoTurnOffGrab());
            }
            else if (isMagnetActive == true && isMagnetHoldingObject == true)
            {
                DropObject();
                updateDroneGrabberUI();
                currentFeatureIndicator.color = Color.red;
            }
        }
    }

    private void updateDroneGrabberUI()
    {
        if (isMagnetActive && isObjectFound)
        {
            currentFeatureIndicator.sprite = activeMagnetObjectSprite;
        }
        else if (isMagnetActive && !isObjectFound)
        {
            currentFeatureIndicator.sprite = activeMagnetNoObjectSprite;
        }
        else if (!isMagnetActive && isObjectFound)
        {
            currentFeatureIndicator.sprite = magnetObjectSprite;
        }
        else if (!isMagnetActive && !isObjectFound)
        {
            currentFeatureIndicator.sprite = initalMagnetSprite;
        }
    }
}
