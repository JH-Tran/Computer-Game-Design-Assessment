using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOrigin : MonoBehaviour
{
    [SerializeField] private Vector3 objectOrigin;

    // Start is called before the first frame update
    void Start()
    {
        objectOrigin = gameObject.transform.position;
    }

    public void setOriginPosition()
    {
        gameObject.transform.position = objectOrigin;
    }
}
