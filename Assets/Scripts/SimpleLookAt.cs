using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLookAt : MonoBehaviour
{
    [SerializeField] bool movement = false;
    [SerializeField] bool orbit = false;
    Vector3 velocity;
    Vector3 acceleration;
    Vector3 mousePos;
    Vector3 diference;
    float radians;

    void Update()
    {
        mousePos = GetWorldMousePosition();
        diference = mousePos - transform.position;
        radians = Mathf.Atan2(diference.y, diference.x);
        transform.localRotation = Quaternion.Euler(0f, 0f, radians * Mathf.Rad2Deg);
        if (movement)
        {
            Move(diference);
        }
        
    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;

        return worldPos;
    }

    void Move(Vector3 direction)
    {
        if(orbit)
        {
            acceleration = direction;
            velocity += acceleration * Time.deltaTime;
        }
        else
        {
            velocity = direction;
        }
        transform.position += velocity * Time.deltaTime;
    }
}
