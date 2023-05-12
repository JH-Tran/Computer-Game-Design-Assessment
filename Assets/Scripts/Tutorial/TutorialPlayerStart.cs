using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerStart : MonoBehaviour
{
    [SerializeField] private FirstPersonController fpController;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        fpController.PlayerCameraLock(false);
=======
        fpController.isPlayerCameraLocked(false);
>>>>>>> origin
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
