using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject levelSelectorUI;

    public void Awake()
    {
        mainMenuUI.SetActive(true);
        levelSelectorUI.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    

    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LoadTest()
    {
        SceneManager.LoadScene("TestScene");
    }
    public void LoadLevelSelector()
    {
        mainMenuUI.SetActive(false);
        levelSelectorUI.SetActive(true);
    }
    public void ExitToMainMenu()
    {
        mainMenuUI.SetActive(true);
        levelSelectorUI.SetActive(false);
    }
}
