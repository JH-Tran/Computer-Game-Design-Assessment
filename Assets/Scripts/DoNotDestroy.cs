using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    [HideInInspector]
    public string objectID;
    private void Awake()
    {
        objectID = name + transform.position.ToString() + transform.eulerAngles.ToString();
    }

    private void Start()
    {
        for (int i = 0; i < Object.FindObjectsOfType<DoNotDestroy>().Length; i++)
        {
            if (Object.FindObjectsOfType<DoNotDestroy>()[i] != this)
            {
                if (Object.FindObjectsOfType<DoNotDestroy>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
