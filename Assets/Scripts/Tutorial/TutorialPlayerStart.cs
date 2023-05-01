using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerStart : MonoBehaviour
{
    [SerializeField] private FirstPersonController fpController;
    // Start is called before the first frame update
    void Start()
    {
        fpController.isPlayerCameraLocked(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
