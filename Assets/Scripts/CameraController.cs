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
        if (Input.GetKey(KeyCode.A))
            cameraTransform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        if (Input.GetKey(KeyCode.D))
            cameraTransform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
    }
}
