using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 2f;
    private bool droneEnable = false;
    public Transform droneBody;
    public Camera droneCamera;

    private float yaw;
    private float pitch;
    private float maxLookAngle = 90f;

    // Start is called before the first frame update
    void Start()
    {
        droneCamera.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (droneEnable)
        {
            CameraLook();
        }
    }

    //Camera look from FirstPersonController Asset by Jesse Case
    private void CameraLook()
    {
        yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");

        // Clamp pitch between lookAngle
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

        transform.localEulerAngles = new Vector3(0, yaw, 0);
        droneCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);

    }

    public void changeDroneState(bool state)
    {
        droneEnable = state;
    }
}
