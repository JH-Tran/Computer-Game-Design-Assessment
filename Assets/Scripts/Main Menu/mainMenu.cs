using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
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
        SceneManager.LoadScene("SelectLevel");
    }
}
