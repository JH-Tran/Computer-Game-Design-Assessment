using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTabletScreen : MonoBehaviour
{
    [SerializeField] private Renderer tabletSceenRender;
    
    [SerializeField] private DroneBattery droneBatteryScript;
    [SerializeField] private Material outOfBatteryMaterial;

    [SerializeField] private Camera mainDroneCamera;
    [SerializeField] private Material mainDroneMaterial;


    // Start is called before the first frame update
    void Start()
    {
        mainDroneCamera = GameObject.Find("DroneMainCamera").GetComponent<Camera>();
<<<<<<< HEAD
        downDroneCamera = GameObject.Find("DroneDownCamera").GetComponent<Camera>();
=======
>>>>>>> origin
        SetUpDroneCameras();
        tabletSceenRender.material = mainDroneMaterial;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SetUpDroneCameras()
    {
        if (mainDroneCamera.targetTexture != null)
        {
            mainDroneCamera.targetTexture.Release();
        }
        mainDroneCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mainDroneMaterial.mainTexture = mainDroneCamera.targetTexture;
    }
}
