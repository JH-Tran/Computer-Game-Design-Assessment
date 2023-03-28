using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    private float moveSpeed = 7;
    private float horizontalInput;
    private float verticalInput;


    public Transform orientation;
    Vector3 moveDirection;

    Rigidbody droneRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        droneRigidbody = GetComponent<Rigidbody>();
        droneRigidbody.useGravity = false;
        droneRigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        DroneGrounded();
        MoveDrone();
        MaxDroneSpeed();
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MoveDrone()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        droneRigidbody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void MaxDroneSpeed()
    {
        Vector3 flatVelocity = new Vector3(droneRigidbody.velocity.x, 0f, droneRigidbody.velocity.z);

        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            droneRigidbody.velocity = new Vector3(limitedVelocity.x, droneRigidbody.velocity.y, limitedVelocity.z);
        }
    }

    private void DroneGrounded()
    {

    }
}
