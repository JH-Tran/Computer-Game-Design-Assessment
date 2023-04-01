using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttachmentManager : MonoBehaviour
{
    [SerializeField] GameObject claw;
    [SerializeField] GameObject attachmentIcons;
    //private bool useItem = true;

    // Start is called before the first frame update
    void Start()
    {
        claw.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (useItem == false)
            {
                claw.SetActive(true);
                useItem = true;
            }
            else if (useItem == true)
            {
                claw.SetActive(false);
                useItem = false;
            }
        }*/
    }
}
