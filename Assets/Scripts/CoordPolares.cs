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

    void Update()
    {
        radialSpeed += radialAcceleration * Time.deltaTime;
        polarCoord.x += radialSpeed * Time.deltaTime;

        angularSpeed += angularAcceleration * Time.deltaTime;
        polarCoord.y += angularSpeed * Time.deltaTime;

        if (Mathf.Abs(polarCoord.x) >= 5)
        {
            if (Mathf.Abs(radialAcceleration) > 0)
            {
                radialAcceleration = -radialAcceleration;
            }
            else
            {
                radialSpeed = -radialSpeed;
            }
        }

        transform.localPosition = PolarToCartesian(polarCoord);

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
}
