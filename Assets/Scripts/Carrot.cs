using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Carrot : Enemy
{
    public float speed = 100;
    public Rigidbody _rigidbody;
    

    private void Start()
    {
        if (FindTarget())
        {
            Vector3 toTarget = target.gameObject.transform.position - transform.position;
            _rigidbody.velocity = toTarget.normalized * speed;
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, -300, 0) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        Die();
    }

}
