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
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadTest()
    {
        SceneManager.LoadScene("TestScene");
    }
    public void LoadLevel()
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
