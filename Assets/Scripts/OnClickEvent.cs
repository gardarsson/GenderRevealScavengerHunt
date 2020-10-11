using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnClickEvent : MonoBehaviour
{
    public UnityEvent myEvent;
    public GameObject questionCanvas, startCanvas, finalCanvas;

    private void Start()
    {
        RectTransform[] panels = FindObjectsOfType<RectTransform>(true);

        foreach (RectTransform panel in panels)
        {
            if (panel.name == "ReorderableLetterCanvas")
                finalCanvas = panel.gameObject;

            if (panel.name == "StartUpMenu")
                startCanvas = panel.gameObject;
        }
    }

    void OnMouseDown()
    {
        if (questionCanvas.activeInHierarchy || startCanvas.activeInHierarchy || finalCanvas.activeInHierarchy)
            return;

        myEvent.Invoke();
    }
}
