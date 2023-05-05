using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDoorManagerLevel3 : MonoBehaviour
{
    private bool target1, target2, target3;
    private Animator doorAnimator;
    private int targetCount = 0;
    [SerializeField] private GameObject[] doorLightIndicator;
    [SerializeField] Material activeIndicator;

    [SerializeField] GameObject cubeBlocker;
    private void Start()
    {
        doorAnimator = gameObject.GetComponent<Animator>();
        target1 = false;
        target2 = false;
        target3 = false;
    }

    private void FixedUpdate()
    {
        if (target1 && target2 && target3)
        {
            doorAnimator.SetTrigger("triggerDoor");
        }
    }
    public void setTargetTrue(int targetID)
    {
        if (targetID.Equals(1))
        {
            if (target1 == false)
            {
                targetCount++;
                updateTargetIndicator();
            }
            target1 = true;
        }
        else if (targetID.Equals(2))
        {
            if (target2 == false)
            {
                targetCount++;
                updateTargetIndicator();
            }
            target2 = true;
        }
        else if (targetID.Equals(3))
        {
            if (target3 == false)
            {
                targetCount++;
                updateTargetIndicator();
            }
            target3 = true;
        }
    }
    public void updateTargetIndicator()
    {
        if (targetCount == 1)
        {
            doorLightIndicator[0].GetComponent<Renderer>().material = activeIndicator;
        }
        if (targetCount == 2)
        {
            doorLightIndicator[1].GetComponent<Renderer>().material = activeIndicator;
            cubeBlocker.SetActive(false);
        }
        if (targetCount == 3)
        {
            doorLightIndicator[2].GetComponent<Renderer>().material = activeIndicator;
        }
    }
}
