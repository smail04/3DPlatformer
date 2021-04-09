using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservationPoint : MonoBehaviour
{
    public Transform player;
    [Range(0, 50)]
    public float lerpValue;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * lerpValue);    
    }
}
