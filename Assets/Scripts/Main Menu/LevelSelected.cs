using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelected : MonoBehaviour
{
    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
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
}

