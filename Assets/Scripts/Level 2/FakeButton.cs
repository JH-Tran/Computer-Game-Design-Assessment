using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeButton : MonoBehaviour
{
    public Material[] material;
    public int x;
    Renderer rend;
    public bool isOpen = false;
    private bool condition = true;

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

    private void OnCollisionEnter(Collision other)
    {
        if (isOpen == false)
        {
            isOpen = true;
            x = 2;
            if (condition == true)
            {
                condition = false;
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (isOpen == true)
        {
            isOpen = false;
            x = 1;
        }
    }
}
