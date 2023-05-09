using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    [SerializeField] private GameObject reactorGlass;
    [SerializeField] private GameObject blackCube;
    [SerializeField] private Material reactorActiveMaterial;
    [SerializeField] private Material notReactorActiveMaterial;
    [SerializeField] private bool isReactorStatic = false;

    private void Awake()
    {
        if (isReactorStatic)
        {
            reactorGlass.GetComponent<Renderer>().material = reactorActiveMaterial;
        }
        else
        {
            reactorGlass.GetComponent<Renderer>().material = notReactorActiveMaterial;
        }

        blackCube.GetComponent<Transform>().rotation = Random.rotation;
    }
}
