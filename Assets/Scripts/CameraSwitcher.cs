using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject livingRoomCamera, nurseryCamera;
    public TextMeshProUGUI textToToggle;

    public void ToggleCameras()
    {
        livingRoomCamera.gameObject.SetActive(!livingRoomCamera.gameObject.active);
        nurseryCamera.gameObject.SetActive(!nurseryCamera.gameObject.active);

        if (!livingRoomCamera.activeInHierarchy)
            textToToggle.text = "Do you want to enter the living room?";
        else
            textToToggle.text = "Do you want to enter the nursery?";
    }
}
