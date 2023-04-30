using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCount : MonoBehaviour
{
    [SerializeField] int targetId;
    [SerializeField] TargetDoorManagerLevel3 door;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            door.setTargetTrue(targetId);
        }
    }
}
