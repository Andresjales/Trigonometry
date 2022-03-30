using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordPolares : MonoBehaviour
{
    [Header("Polar Coord")]
    [SerializeField] Vector2 polarCoord;

    [Header("Radial Speed")]
    [SerializeField] float radialAcceleration;
    [SerializeField] float radialSpeed;

    [Header("Angular Speed")]
    [SerializeField] float angularAcceleration;
    [SerializeField] float angularSpeed;
    
    void Update()
    {
        radialSpeed += radialAcceleration * Time.deltaTime;
        polarCoord.x += radialSpeed * Time.deltaTime;

        angularSpeed += angularAcceleration * Time.deltaTime;
        polarCoord.y += angularSpeed * Time.deltaTime;

        transform.position = PolarToCartesian(polarCoord);

        DrawPolar(polarCoord);

        if (Mathf.Abs(polarCoord.x) >= 5)
        {
            radialSpeed *= -1;
        }
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
