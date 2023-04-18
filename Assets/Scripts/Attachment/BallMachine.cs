using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMachine : MonoBehaviour
{
    [SerializeField] private Transform launchTransform;

    [SerializeField] private GameObject ball;
    private float launchVelocity = 15f;

    //Cooldown of ability

    //If there are more than one ball than the other one will despawn

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var prefabBall = Instantiate(ball, launchTransform.position, launchTransform.rotation);
            prefabBall.GetComponent<Rigidbody>().velocity = launchTransform.forward * launchVelocity;
        }
    }
}
