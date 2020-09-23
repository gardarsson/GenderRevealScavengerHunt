using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoverController : MonoBehaviour
{
    void OnMouseOver()
    {
        Debug.Log("Mouse is over");
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse is no longer on object");
    }
}
