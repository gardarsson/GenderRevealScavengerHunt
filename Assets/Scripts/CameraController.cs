using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;

    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = transform;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            cameraTransform.localPosition += cameraTransform.right * (-speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            cameraTransform.localPosition += cameraTransform.right * (speed * Time.deltaTime);
    }
}
