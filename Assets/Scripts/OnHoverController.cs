using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnHoverController : MonoBehaviour
{
    public Material glowMaterial;
    public GameObject questionCanvas, startCanvas, finalCanvas;

    private Dictionary<GameObject, Material[]> storedMaterials = new Dictionary<GameObject, Material[]>();

    void Start()
    {
        RectTransform[] panels = FindObjectsOfType<RectTransform>(true);

        foreach(RectTransform panel in panels)
        {
            if (panel.name == "ReorderableLetterCanvas")
                finalCanvas = panel.gameObject;

            if (panel.name == "StartUpMenu")
                startCanvas = panel.gameObject;
        }

        foreach(Transform t in GetComponentsInChildren<Transform>())
        {
            if(t.GetComponent<Renderer>() != null)
            {
                storedMaterials.Add(t.gameObject, t.gameObject.GetComponent<Renderer>().sharedMaterials);
            }
        }
    }

    void OnMouseEnter()
    {
        if (questionCanvas.activeInHierarchy || startCanvas.activeInHierarchy || finalCanvas.activeInHierarchy)
            return;

        SoundManager.instance.PlayHoverSound();

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
