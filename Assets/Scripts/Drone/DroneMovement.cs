using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DroneMovement : MonoBehaviour
{
    private float moveSpeed = 10;
    private float droneDownSpeed = 70;
    private float droneUpSpeed = 70;
    private float horizontalInput;
    private float verticalInput;

    private bool droneEnable = true;

    public Transform orientation;
    Vector3 moveDirection;

    [SerializeField] Rigidbody droneRigidbody;
    [SerializeField] private Transform checkpointTransform;

    // Start is called before the first frame update
    void Start()
    {
        droneRigidbody = gameObject.GetComponent<Rigidbody>();
        droneRigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        if (droneEnable == true)
        {
            droneRigidbody.useGravity = false;
            MoveDrone();
            DroneMoveUp();
            DroneMoveDown();
            MaxDroneSpeed();
        }
    }
    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    public void changeDroneState(bool state)
    {
        droneEnable = state;
    }
    public void changeDroneGravity(bool state)
    {
        droneRigidbody.useGravity = state;
    }
    public void resetToCheckpoint()
    {
        gameObject.transform.position = checkpointTransform.position;
        gameObject.transform.rotation = checkpointTransform.rotation;
        droneRigidbody.velocity = Vector3.zero;
        droneRigidbody.angularVelocity = Vector3.zero;
    }
    public void updateCheckpointPosition(Transform updatedTransform) 
    {
        checkpointTransform = updatedTransform;
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

    private void DroneMoveUp()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            droneRigidbody.AddForce(Vector3.up * droneUpSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            droneRigidbody.velocity = Vector3.zero;
            droneRigidbody.angularVelocity = Vector3.zero;
        }
    }

    private void DroneMoveDown()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            droneRigidbody.AddForce(Vector3.down * droneDownSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            droneRigidbody.velocity = Vector3.zero;
            droneRigidbody.angularVelocity = Vector3.zero;
        }
    }

    public float getDroneVelocity()
    {
        return gameObject.GetComponent<Rigidbody>().velocity.magnitude;
    }
    public bool getDroneEnable()
    {
        return droneEnable;
    }
}
