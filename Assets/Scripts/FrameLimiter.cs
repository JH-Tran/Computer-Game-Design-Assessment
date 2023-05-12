using System;
using UnityEngine;
using UnityEngine.UI;

public class FrameLimiter : MonoBehaviour
{
    private int lastFrameIndex;
    private float[] frameDeltaTimeArray = new float[50];
    [SerializeField] private Text fpsText;

    private void Start()
    {
        Application.targetFrameRate = -1;
    }

    private void Update()
    {
        frameDeltaTimeArray[lastFrameIndex] = Time.deltaTime;
        lastFrameIndex = (lastFrameIndex + 1) % frameDeltaTimeArray.Length;
        fpsText.text = "FPS:" + Mathf.RoundToInt(CalculatedFPS()).ToString();
    }

    private float CalculatedFPS()
    {
        float total = 0f;
        foreach(float deltaTime in frameDeltaTimeArray)
        {
            total += deltaTime;
        }
        return frameDeltaTimeArray.Length / total;
    }
}
