using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtonPressed : MonoBehaviour
{
    public Material[] material;
    public int x;
    public Renderer rend;
    public bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        x = 1;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[x];
    }
}
