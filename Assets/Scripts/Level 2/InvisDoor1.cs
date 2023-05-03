using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisDoor1 : MonoBehaviour
{
    public int lightsGreen = 0;
    public int greenLightsNeeded;
    private bool isDoorOpen = false;
    public Animator doorAnim;
    // Start is called before the first frame update
    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsGreen == greenLightsNeeded && isDoorOpen == false)
        {
            doorAnim.SetBool("isOpen", true);
            isDoorOpen = true;
        }
    }
}
