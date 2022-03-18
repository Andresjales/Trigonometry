using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordPolares : MonoBehaviour
{
    [SerializeField] Vector2 polarCoord;
    [SerializeField] float radialAcceleration;
    [SerializeField] float angularAcceleration;
    float radialSpeed;
    float angularSpeed;

    [Header("World Limits")]
    [SerializeField] float xBorder;
    [SerializeField] float yBorder;

    void Update()
    {
        radialSpeed += radialAcceleration * Time.deltaTime;
        polarCoord.x += radialSpeed * Time.deltaTime;

        angularSpeed += angularAcceleration * Time.deltaTime;
        polarCoord.y += angularSpeed * Time.deltaTime;

        transform.localPosition = PolarToCartesian(polarCoord);

        CheckCollisions();

        DrawPolar(polarCoord);
    }

    void DrawPolar(Vector2 polarCord)
    {

        Debug.DrawLine(Vector3.zero, PolarToCartesian(polarCord), Color.cyan);
    }

    private Vector3 PolarToCartesian(Vector2 polar)
    {
        float r = polar.x;
        Vector3 rad = new Vector3(Mathf.Cos(polar.y) * r, Mathf.Sin(polar.y) * r);
        return rad;
    }

    private void CheckCollisions()
    {
        if (transform.position.x >= xBorder || transform.position.x <= -xBorder)
        {
            if (transform.position.x >= xBorder)
            {
                transform.position = new Vector3(xBorder, transform.position.y, 0);
            }
            else if (transform.position.x <= -xBorder)
            {
                transform.position = new Vector3(-xBorder, transform.position.y, 0);
            }

            radialSpeed *= -1;
        }
        else if (transform.position.y >= yBorder || transform.position.y <= -yBorder)
        {
            if (transform.position.y >= yBorder)
            {
                transform.position = new Vector3(transform.position.x, yBorder, 0);
            }
            else if (transform.position.y <= -yBorder)
            {
                transform.position = new Vector3(transform.position.x, -yBorder, 0);
            }

            radialSpeed*= -1;
        }
    }
}
