using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;

    private Transform cameraTransform;
    private Material fadeMaterial;

    void OnEnable()
    {
        cameraTransform = transform;
        fadeMaterial = GetComponentInChildren<MeshRenderer>().material;
        fadeMaterial.color = new Color(fadeMaterial.color.r, fadeMaterial.color.g, fadeMaterial.color.b, 1);

        StartCoroutine(FadeMaterial(fadeMaterial));
    }

    void OnDisable()
    {
        fadeMaterial = GetComponentInChildren<MeshRenderer>().material;
        fadeMaterial.color = new Color(fadeMaterial.color.r, fadeMaterial.color.g, fadeMaterial.color.b, 1);
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            cameraTransform.localPosition += cameraTransform.right * (-speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            cameraTransform.localPosition += cameraTransform.right * (speed * Time.deltaTime);
    }

    private IEnumerator FadeMaterial(Material mat)
    {
        for(float i = 1; i >= 0; i -= 0.05f)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, i);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
