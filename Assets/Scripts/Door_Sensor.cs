using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Sensor : MonoBehaviour
{
    public Animator doorAnim;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        doorAnim = this.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        doorAnim.SetBool("isOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnim.SetBool("isOpen", false);
    }
}
