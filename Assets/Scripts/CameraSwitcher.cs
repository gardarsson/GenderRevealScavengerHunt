using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject livingRoomCamera, nurseryCamera;

    void OnMouseDown()
    {
        livingRoomCamera.gameObject.SetActive(!livingRoomCamera.gameObject.active);
        nurseryCamera.gameObject.SetActive(!nurseryCamera.gameObject.active);
    }
}
