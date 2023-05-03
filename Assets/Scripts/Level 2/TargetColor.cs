using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetColor : MonoBehaviour
{
    public Material[] material;
    public int x;
    Renderer rend;
    public bool isOpen = false;
    private bool condition = true;
    public InvisDoor1 lockedDoor;

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
        if (other.gameObject.tag == "Ball")
        {
            if (isOpen == false)
            {
                lockedDoor.lightsGreen += 1;
                isOpen = true;
                x = 2;
                if (condition == true)
                {
                    condition = false;
                }
            }
        }

    }
}
