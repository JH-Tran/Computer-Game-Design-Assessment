using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{
    private Rigidbody ballRigid;
    // Start is called before the first frame update
    void Start()
    {
        ballRigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        ballRigid.useGravity = true;
    }
}
