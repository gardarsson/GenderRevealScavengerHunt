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
            textToToggle.text = "Viltu fara í stofuna?";
        else
            textToToggle.text = "Viltu fara í barnaherbergið?";
    }

    public void ActivateCamera(GameObject camera)
    {
        camera.gameObject.SetActive(true);
    }
}
