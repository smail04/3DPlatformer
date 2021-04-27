using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform crosshair;
    public Transform head;

    void Update()
    {
        Vector3 toCrosshair = crosshair.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toCrosshair);        
        //head.rotation = Quaternion.Lerp(head.rotation, Quaternion.Euler(0, ((toCrosshair.x > 0)? -45 : 45), 0), Time.deltaTime * 15);
    }
}
