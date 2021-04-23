using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int segmentCount = 10; 

    public void Draw(Vector3 a, Vector3 b, float length)
    {
        lineRenderer.enabled = true;

        float interpolant = Vector3.Distance(a, b) / length;
        float offset = Mathf.Lerp(length / 2, 0, interpolant);

        Vector3 aDown = a + Vector3.down * offset;
        Vector3 bDown = b + Vector3.down * offset;

        lineRenderer.positionCount = segmentCount + 1;
        for (int i = 0; i < lineRenderer.positionCount; i++)
            lineRenderer.SetPosition(i, Bezier.GetPoint(a, aDown, bDown, b, (float)i / segmentCount));

    }

    public void Hide()
    {
        lineRenderer.enabled = false;
    }
}
