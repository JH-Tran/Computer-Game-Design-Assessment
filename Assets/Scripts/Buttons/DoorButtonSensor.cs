using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonSensor : MonoBehaviour
{
    public GameObject door;
    public Animator doorAnim;

    public GameObject playerButton;
    public Animator playerButtonAnim;
    public bool soundPlayed = false;
    public AudioSource doorSound;

    public ButtonPressed button;
    // Start is called before the first frame update
    void Start()
    {
        doorAnim = door.GetComponent<Animator>();
        playerButtonAnim = playerButton.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button.isOpen == true)
        {
            doorAnim.SetBool("isOpen", true);
            playerButtonAnim.SetBool("isActive", true);
            if(soundPlayed == false)
            {
                doorSound.Play();
                soundPlayed = true;
            }
        }
        else
        {
            doorAnim.SetBool("isOpen", false);
            soundPlayed = false;
        }
    }
}
