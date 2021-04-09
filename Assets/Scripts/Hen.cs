using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hen : Enemy
{
    public float moveSpeed = 5;
    public float accelerationTime = 1;
    public Rigidbody _rigidbody;

    private void FixedUpdate()
    {
        if (FindTarget())
        {
            Vector3 toTarget = target.gameObject.transform.position - transform.position;
            Vector3 force = _rigidbody.mass * (toTarget.normalized * moveSpeed - _rigidbody.velocity) / accelerationTime;
            _rigidbody.AddForce(force, ForceMode.Force);
        }
    }
}
