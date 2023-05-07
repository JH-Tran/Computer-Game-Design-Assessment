using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBlockers : MonoBehaviour
{
    [SerializeField] GameObject blocker;
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
            blocker.SetActive(false);
        }
    }
}
