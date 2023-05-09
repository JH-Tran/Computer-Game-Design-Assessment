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
            activateReactor();
        }
        else
        {
            deactivateReactor();
        }
        blackCube.GetComponent<Transform>().rotation = Random.rotation;
    }

    public void activateReactor()
    {
        reactorGlass.GetComponent<Renderer>().material = reactorActiveMaterial;
    }

    public void deactivateReactor()
    {
        reactorGlass.GetComponent<Renderer>().material = notReactorActiveMaterial;
    }
}
