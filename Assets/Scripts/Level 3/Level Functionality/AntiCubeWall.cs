using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiCubeWall : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            other.GetComponent<ObjectOrigin>().setOriginPosition();
        }
        else if (other.CompareTag("Ball"))
        {
            Destroy(other);
        }
    }
}
