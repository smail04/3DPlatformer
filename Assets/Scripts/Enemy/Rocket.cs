using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rocket : Enemy
{
    public float speed = 1;
    public float rotationSpeed = 1;
    private Transform childTransform;

    private new void Start()
    {
        base.Start();
        childTransform = transform.GetChild(0);
    }

    void Update()
    {
        childTransform.Rotate(new Vector3(0, 300, 0) * Time.deltaTime);
        if (FindTarget())
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            Vector3 toTarget = target.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(toTarget, Vector3.forward), rotationSpeed * Time.deltaTime);
        }
    }

    private new void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        Die();
    }
}
