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
            currentGraphicsQuality.text = currentGraphicsBasicText + "High";
        }
        else if (QualitySettings.GetQualityLevel() == 1)
        {
            currentGraphicsQuality.text = currentGraphicsBasicText + "Medium";
        }
        else if (QualitySettings.GetQualityLevel() == 0)
        {
            currentGraphicsQuality.text = currentGraphicsBasicText + "Low";
        }

    }
    public void goodGraphics()
    {
        QualitySettings.SetQualityLevel(2, true);
        currentGraphicsQuality.text = currentGraphicsBasicText + "High";
    }
    public void lowGraphics()
    {
        QualitySettings.SetQualityLevel(1, true);
        currentGraphicsQuality.text = currentGraphicsBasicText + "Medium";
    }
    public void fastestGraphics()
    {
        QualitySettings.SetQualityLevel(0, true);
        currentGraphicsQuality.text = currentGraphicsBasicText + "Low";
    }
}
