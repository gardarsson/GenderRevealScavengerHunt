using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnClickEvent : MonoBehaviour
{
    public UnityEvent myEvent;
    public GameObject questionCanvas;

    void OnMouseDown()
    {
        if (questionCanvas.activeInHierarchy)
            return;

        myEvent.Invoke();
    }
}
