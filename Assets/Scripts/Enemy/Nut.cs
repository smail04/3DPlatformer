using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Nut : Enemy
{
    public Vector3 velocity;
    public float maxAngularSpeed;

    private new void Start()
    {
        Rigidbody _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddRelativeForce(velocity, ForceMode.VelocityChange);
        _rigidbody.angularVelocity = new Vector3(Random.Range(-maxAngularSpeed, maxAngularSpeed), 
                                                Random.Range(-maxAngularSpeed, maxAngularSpeed), 
                                                Random.Range(-maxAngularSpeed, maxAngularSpeed));
    }

    private new void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        Die();
    }

}
