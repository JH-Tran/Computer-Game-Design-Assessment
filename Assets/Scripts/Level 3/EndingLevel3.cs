using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingLevel3 : MonoBehaviour
{
    [SerializeField] private PlayerEndingInformation playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerEndingInformation>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Drone")
        {
            if (playerInfo != null)
            {
                playerInfo.isLevel3SecretActive = true;
            }
            SceneManager.LoadScene("MainMenu");
        }
    }
}
