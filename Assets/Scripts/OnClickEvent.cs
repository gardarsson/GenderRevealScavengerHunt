using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnClickEvent : MonoBehaviour
{
    public UnityEvent myEvent;

    void OnMouseDown()
    {
        myEvent.Invoke();
    }
}
