using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretTrigger : MonoBehaviour
{
    public GameObject trigger;
    public GameObject secretBox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == secretBox)
        {
            trigger.SetActive(true);
        }
    }
}
