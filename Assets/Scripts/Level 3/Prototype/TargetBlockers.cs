using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBlockers : MonoBehaviour
{
    [SerializeField] GameObject blocker;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            blocker.SetActive(false);
        }
    }
}
