using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisDoor2 : MonoBehaviour
{
    public int lightsGreen = 0;
    public int greenLightsNeeded;
    private bool isOpen = false;
    public Animator doorAnim;
    // Start is called before the first frame update
    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsGreen == greenLightsNeeded && isOpen == false)
        {
            doorAnim.SetBool("isOpen", true);
            isOpen = true;
        }

        else if (lightsGreen > greenLightsNeeded && isOpen == true)
        {
            doorAnim.SetBool("isOpen", false);
            isOpen = false;
        }

        else if (lightsGreen < greenLightsNeeded && isOpen == true)
        {
            doorAnim.SetBool("isOpen", false);
            isOpen = false;
        }
    }
}
