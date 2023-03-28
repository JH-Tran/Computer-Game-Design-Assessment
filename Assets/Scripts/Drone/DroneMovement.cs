using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    private float moveSpeed = 3;

    public Transform orientation;
    private float horizontalInput;
    private float verticalInput;

    Vector3 moveDirection;

    Rigidbody droneRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        droneRigidbody = GetComponent<Rigidbody>();
        droneRigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        MoveDrone();
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MoveDrone()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        droneRigidbody.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);
    }
}
