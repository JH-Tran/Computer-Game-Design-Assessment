using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourButtonFunction : MonoBehaviour, IInteractable
{
    [SerializeField] private Material materialType;
    [SerializeField] private Material activeButtonMaterial;
    [SerializeField] private List<GameObject> objectChanger = new List<GameObject>();

    public void Interact()
    {
        //Debug.Log("Interacted with this Button: " + materialType.name);
        GetComponent<Renderer>().material = activeButtonMaterial;
        StartCoroutine(resetColourButton(1));
        foreach (GameObject gameO in objectChanger) {
            gameO.GetComponentInChildren<ObjectChangerPlatform>().changeObjectMaterials(materialType);
        }
    }
    private IEnumerator resetColourButton(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            GetComponent<Renderer>().material = materialType;
            StopAllCoroutines();
        }
    }
}
