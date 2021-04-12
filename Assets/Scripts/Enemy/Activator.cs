using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public Transform playerTransform;
    public List<ActivateByDistance> objectsToActivate = new List<ActivateByDistance>();

    private void Update()
    {
        foreach (var obj in objectsToActivate)
        {
            obj.CheckDistance(playerTransform.position);
        }
    }
}
