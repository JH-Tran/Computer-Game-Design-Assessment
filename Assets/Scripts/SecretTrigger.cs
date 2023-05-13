using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretTrigger : MonoBehaviour
{
    public GameObject trigger;
    public GameObject secretBox;
    [SerializeField] private PlayerEndingInformation playerInfo;

    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerEndingInformation>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == secretBox)
        {
            trigger.SetActive(true);
            if (playerInfo != null)
            {
                playerInfo.isLevel2SecretActive = true;
            }
        }
    }
}
