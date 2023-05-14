using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisDoor1 : MonoBehaviour
{
    public int lightsGreen = 0;
    public int greenLightsNeeded;
    private bool isDoorOpen = false;
    public Animator doorAnim;
    public AudioSource doorSound;
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
            doorSound.Play();
            doorAnim.SetBool("isOpen", true);
            isDoorOpen = true;
        }
    }
}
