using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnHoverController : MonoBehaviour
{
    public Material glowMaterial;
    public GameObject questionCanvas;

    private Dictionary<GameObject, Material[]> storedMaterials = new Dictionary<GameObject, Material[]>();

    void Start()
    {
        foreach(Transform t in GetComponentsInChildren<Transform>())
        {
            if(t.GetComponent<Renderer>() != null)
            {
                storedMaterials.Add(t.gameObject, t.gameObject.GetComponent<Renderer>().sharedMaterials);
            }
        }
    }

    void OnMouseOver()
    {
        if (questionCanvas.activeInHierarchy)
            return;

        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t.gameObject.GetComponent<Renderer>() != null)
            {
                Material[] mats = t.gameObject.GetComponent<Renderer>().sharedMaterials;

                for (int i = 0; i < mats.Length; i++)
                    mats[i] = glowMaterial;

                t.gameObject.GetComponent<Renderer>().sharedMaterials = mats;
            }
        }
    }

    void OnMouseExit()
    {
        foreach(KeyValuePair<GameObject, Material[]> keyValuePair in storedMaterials)
        {
            keyValuePair.Key.GetComponent<Renderer>().sharedMaterials = keyValuePair.Value;
        }
    }
}
