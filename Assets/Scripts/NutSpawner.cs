using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSpawner : MonoBehaviour
{
    public GameObject nutPrefab;
    public Transform[] points;

    public void Create()
    {
        foreach (Transform point in points)
            Instantiate(nutPrefab, point.position, point.rotation);
    }
}
