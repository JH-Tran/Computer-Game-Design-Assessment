using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuObject;
    [SerializeField] FirstPersonController fpcScript;
    [SerializeField] DroneCamera droneCamScript;
    [SerializeField] bool isDroneFound = true;
    private bool isGamePaused = false;
    private bool isPlayerCameraLocked = false;
    private bool isDroneCameraLocked = false;

    private void Awake()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    private void Start()
    {
        if (isDroneFound == true)
            droneCamScript = GameObject.Find("Drone1.0").GetComponent<DroneCamera>();
        pauseMenuObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        fpcScript.lockCursor = true;
        fpcScript.isPlayerCameraLocked(isPlayerCameraLocked);
        if (isDroneFound)
            droneCamScript.changeDroneState(isDroneCameraLocked);

        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    private void PauseGame()
    {
        fpcScript.lockCursor = false;
        //Get camera lock
        isPlayerCameraLocked = fpcScript.getPlayerCameraLock();
        fpcScript.isPlayerCameraLocked(true);
        if (isDroneFound)
        {
            isDroneCameraLocked = droneCamScript.getDroneState();
            droneCamScript.changeDroneState(false);
        }

        pauseMenuObject.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void droneFound()
    {
        droneCamScript = GameObject.Find("Drone1.0").GetComponent<DroneCamera>();
        isDroneFound = true;
    }
}
