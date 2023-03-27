using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTabletScreen : MonoBehaviour
{
    [SerializeField] private Camera mainDroneCamera;
    [SerializeField] private Material mainDroneMaterial;

    [SerializeField] private Camera downDroneCamera;
    [SerializeField] private Material downDroneMaterial;


    // Start is called before the first frame update
    void Start()
    {
        if (mainDroneCamera.targetTexture != null)
        {
            mainDroneCamera.targetTexture.Release();
        }
        mainDroneCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mainDroneMaterial.mainTexture = mainDroneCamera.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
