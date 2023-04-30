using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretEndingManager : MonoBehaviour
{
    [SerializeField] bool[] isBasketColourVerifiedList;
    //Ending platform 1 is the finishing platform
    [SerializeField] GameObject[] endingPlatform;

    private void Start()
    {
        endingPlatform[1].SetActive(false);
    }
    public void setBasketVerification(int basketId, bool isBasketCorrect)
    {
        isBasketColourVerifiedList[basketId] = isBasketCorrect;
        if (isBasketCorrect == true)
        {
            isEveryBasketTrue();
        }
        else if (isBasketCorrect == false)
        {
            Debug.Log("TAKE AWAY");
        }
    }

    private void isEveryBasketTrue()
    {
        int basketCount = 0;
        foreach(bool isActiveBasket in isBasketColourVerifiedList)
        {
            if (isActiveBasket == true)
                basketCount++;
        }
        if (basketCount == isBasketColourVerifiedList.Length)
        {
            isEndingActive(true);
        }
        else
        {
            isEndingActive(false);
        }
    }
    private void isEndingActive(bool isEndActive)
    {
        if (isEndActive == true)
        {
            endingPlatform[0].SetActive(false);
            endingPlatform[1].SetActive(true);
        }
        else
        {
            endingPlatform[0].SetActive(true);
            endingPlatform[1].SetActive(false);
        }
    }
}
