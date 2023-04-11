using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject droneCamera;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private bool isPlayerCameraOn = false;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (isPlayerCameraOn == false)
            {
                droneCamera.SetActive(false);
                playerCamera.SetActive(true);
                isPlayerCameraOn = true;
            }
            else
            {
                droneCamera.SetActive(true);
                playerCamera.SetActive(false);
                isPlayerCameraOn = false;
            }
        }
    }

    private void OnApplicationFocus(bool focus)

    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
    }
}
