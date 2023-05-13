using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorLevelConnector : Reactor
{
    [SerializeField] private PlayerEndingInformation playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerEndingInformation>();
        if (playerInfo.isLevel2SecretActive == true)
        {
            activateReactor();
        }
        else
        {
            deactivateReactor();
        }

    }
}
