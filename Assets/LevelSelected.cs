using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelected : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void PlayLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("welcome");
    }
}

