using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 175f;
    private bool droneEnable = false;
    public Transform droneBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (droneEnable)
        {
            CameraLook();
        }
    }

    private void CameraLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        droneBody.Rotate(Vector3.up * mouseX);
    }

    public void changeDroneState(bool state)
    {
        droneEnable = state;
    }
}
