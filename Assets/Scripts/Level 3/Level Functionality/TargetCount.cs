using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCount : MonoBehaviour
{
    [SerializeField] int targetId;
    [SerializeField] TargetDoorManagerLevel3 door;
    [SerializeField] Material targetHitMaterial;
    [SerializeField] GameObject[] TargetObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            foreach (GameObject i in TargetObject)
            {
                i.GetComponent<Renderer>().material = targetHitMaterial;
            }
            door.setTargetTrue(targetId);
        }
    }
}
