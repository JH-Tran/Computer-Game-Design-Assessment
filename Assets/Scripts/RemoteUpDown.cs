using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteUpDown : MonoBehaviour
{
    [SerializeField] FirstPersonController playerCam;

    private Animator anim;
    private bool lookingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(lookingUp == true)
            {
                anim.SetBool("isHolding", false);
                lookingUp = false;
            }
            else
            {
                anim.SetBool("isHolding", true);
                lookingUp = true;
            }
            playerCam.PlayerCameraLock(lookingUp);
        }
    }
}
