using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLookAt : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = GetWorldMousePosition();
        Vector3 diference = mousePos - transform.position;
        float radians = Mathf.Atan2(diference.y, diference.x);
        transform.localRotation = Quaternion.Euler(0f, 0f, radians * Mathf.Rad2Deg);
    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;

        return worldPos;
    }
}
