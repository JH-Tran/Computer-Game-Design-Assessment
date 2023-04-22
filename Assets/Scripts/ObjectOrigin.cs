using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOrigin : MonoBehaviour
{
    private Vector3 objectOrigin;
    private Material originalMaterial;

    // Start is called before the first frame update
    void Start()
    {
        //Automatically set values of object origin and material
        objectOrigin = gameObject.transform.position;
        originalMaterial = gameObject.GetComponent<Renderer>().material;
    }

    public void setOriginPosition()
    {
        if (gameObject.transform.parent != null)
        {
            gameObject.GetComponentInParent<ClawGrabber>().ForceDropObject();
            gameObject.transform.parent = null;
        }
        if (gameObject.GetComponent<Renderer>().material != originalMaterial)
        {
            gameObject.GetComponent<Renderer>().material = originalMaterial;
        }
        gameObject.transform.position = objectOrigin;
    }
}
