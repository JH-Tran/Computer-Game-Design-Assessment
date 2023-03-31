using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawGrabber : MonoBehaviour
{
    [SerializeField] private BoxCollider clawCollider;
    [SerializeField] private Transform clawInitalPosition;

    public bool isGrabbingObject = false;
    public bool isObjectHold = false;
    public List<GameObject> objectGrabbed = new List<GameObject>();

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (isGrabbingObject == false)
            {
                isGrabbingObject = true;
            }
            else if (isGrabbingObject == true)
            {
                DropObject();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Object"))
        {
            if (isGrabbingObject == true && isObjectHold == false)
            {
                other.transform.parent = gameObject.transform;
                objectGrabbed.Add(other.gameObject);
                isObjectHold = true;
                Destroy(other.GetComponent<Rigidbody>());
            }
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
                    Debug.Log("BODY");
                }
                objectGrabbed[i].transform.parent = null;
                Debug.Log("PARENT");
            }
            objectGrabbed.Clear();
            isObjectHold = false;
        }
        isGrabbingObject = false;
    }
}
