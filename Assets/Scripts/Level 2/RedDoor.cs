using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour
{
    public Material[] material;
    public int x;
    Renderer rend;
    public bool isOpen = false;

    [SerializeField] private Transform redDoor;

    private Rigidbody doorRigid;
    private float speed = 1f;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;
    private float current, target;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = gameObject.transform.position;
        x = 1;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
        doorRigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[x];
        if(isOpen == true)
        {
            if (target == 0)
            {
                target = 1;
            }
        }
        else if (isOpen == false)
        {
            if (target == 1)
            {
                target = 0;
            }
        }

        current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);
        doorRigid.MovePosition(Vector3.Lerp(startPoint, endPoint, current));
    }
}
