using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    [SerializeField] private string TestScene = "TestScene";
    public void TutButton()
    {
        SceneManager.LoadScene(TestScene);
    }
}
