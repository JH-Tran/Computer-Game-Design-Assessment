using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorLevel3 : Interactor
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInteracting == true)
        {
            playerInteraction();
        }
        
    }
}
