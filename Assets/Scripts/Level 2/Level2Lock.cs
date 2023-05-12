using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Lock : MonoBehaviour
{
    public TargetColor color;
    public Material[] material;
    public int x;
    public Renderer rend;
    public bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        x = color.x;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[color.x];
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[color.x];
    }
}
