using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 175f;
    private bool droneEnable = false;
    public Transform droneBody;
    public Camera cameraObject;

    float xRotation;
    float yRotation;

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
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraObject.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        droneBody.rotation = Quaternion.Euler(0, yRotation, 0);
        
    }

    public void changeDroneState(bool state)
    {
        droneEnable = state;
    }
}
