using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] Text currentGraphicsQuality;
    private string currentGraphicsBasicText = "Current Graphics: ";
    public void Awake()
    {
        if (QualitySettings.GetQualityLevel() == 2)
        {
            currentGraphicsQuality.text = currentGraphicsBasicText + "Good";
        }
        else if (QualitySettings.GetQualityLevel() == 1)
        {
            currentGraphicsQuality.text = currentGraphicsBasicText + "Low";
        }
        else if (QualitySettings.GetQualityLevel() == 2)
        {
            currentGraphicsQuality.text = currentGraphicsBasicText + "Fastest";
        }

    }
    public void goodGraphics()
    {
        QualitySettings.SetQualityLevel(2, true);
        currentGraphicsQuality.text = currentGraphicsBasicText + "Good";
    }
    public void lowGraphics()
    {
        QualitySettings.SetQualityLevel(1, true);
        currentGraphicsQuality.text = currentGraphicsBasicText + "Low";
    }
    public void fastestGraphics()
    {
        QualitySettings.SetQualityLevel(0, true);
        currentGraphicsQuality.text = currentGraphicsBasicText + "Fastest";
    }
}
