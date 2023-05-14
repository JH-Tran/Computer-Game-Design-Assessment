using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject levelSelectorUI;
    [SerializeField] private GameObject graphicSettingUI;
    public AudioSource menuClick;

    public void Awake()
    {
        mainMenuUI.SetActive(true);
        levelSelectorUI.SetActive(false);
        graphicSettingUI.SetActive(false);
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
        graphicSettingUI.SetActive(false);
        menuClick.Play();
    }
    public void LoadGraphicSettingUI()
    {
        mainMenuUI.SetActive(false);
        levelSelectorUI.SetActive(false);
        graphicSettingUI.SetActive(true);
        menuClick.Play();
    }
    public void ExitToMainMenu()
    {
        mainMenuUI.SetActive(true);
        levelSelectorUI.SetActive(false);
        graphicSettingUI.SetActive(false);
        menuClick.Play();
    }
}
