using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private Plane plane;

    void Start()
    {
        plane = new Plane(Vector3.forward, Vector3.zero);
    }

    private void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);        

        float distance;

        plane.Raycast(ray, out distance);

        Vector3 point = ray.GetPoint(distance);

        gameObject.transform.position = point;
    }
}
