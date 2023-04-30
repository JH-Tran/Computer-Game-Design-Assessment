using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourButtonFunction : MonoBehaviour, IInteractable
{
    [SerializeField] private Material materialType;
    [SerializeField] private List<GameObject> objectChanger = new List<GameObject>();

    public void Interact()
    {
        //Debug.Log("Interacted with this Button: " + materialType.name);
        foreach(GameObject gameO in objectChanger) {
            gameO.GetComponentInChildren<ObjectChangerPlatform>().changeObjectMaterials(materialType);
        }
    }
}
