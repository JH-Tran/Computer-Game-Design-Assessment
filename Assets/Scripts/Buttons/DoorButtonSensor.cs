using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonSensor : MonoBehaviour
{
    public GameObject door;
    public Animator doorAnim;
    public ButtonPressed button;
    // Start is called before the first frame update
    void Start()
    {
        doorAnim = door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button.isOpen == true)
        {
            doorAnim.SetBool("isOpen", true);
        }
        else
        {
            doorAnim.SetBool("isOpen", false);
        }
    }
}
