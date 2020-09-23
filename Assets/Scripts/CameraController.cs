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
            cameraTransform.localPosition += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            cameraTransform.localPosition += new Vector3(speed * Time.deltaTime, 0f, 0f);
    }
}
