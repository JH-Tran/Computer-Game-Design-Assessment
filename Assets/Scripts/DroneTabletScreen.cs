using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTabletScreen : MonoBehaviour
{
    [SerializeField] private Renderer tabletSceenRender;

    [SerializeField] private Camera mainDroneCamera;
    [SerializeField] private Material mainDroneMaterial;

    [SerializeField] private Camera downDroneCamera;
    [SerializeField] private Material downDroneMaterial;


    // Start is called before the first frame update
    void Start()
    {
        SetUpDroneCameras();
        tabletSceenRender.material = mainDroneMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
        {
            if (tabletSceenRender.material.name.Replace(" (Instance)", "") == mainDroneMaterial.name)
            {
                tabletSceenRender.material = downDroneMaterial;
            }
            else if (tabletSceenRender.material.name.Replace(" (Instance)", "") == downDroneMaterial.name)
            {
                tabletSceenRender.material = mainDroneMaterial;
            }

        }
    }
    private void SetUpDroneCameras()
    {
        if (mainDroneCamera.targetTexture != null)
        {
            mainDroneCamera.targetTexture.Release();
        }
        if (downDroneCamera.targetTexture != null)
        {
            downDroneCamera.targetTexture.Release();
        }
        mainDroneCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mainDroneMaterial.mainTexture = mainDroneCamera.targetTexture;

        downDroneCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        downDroneMaterial.mainTexture = downDroneCamera.targetTexture;
    }
}