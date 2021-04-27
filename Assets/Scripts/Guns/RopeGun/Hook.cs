using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public RopeGun ropeGun;
    public new Rigidbody rigidbody;
    public Collider selfCollider;
    public Collider[] ignorableColliders; 
    private FixedJoint _fixedJoint;

    private void Start()
    {
        foreach (Collider otherCollider in ignorableColliders)
            Physics.IgnoreCollision(selfCollider, otherCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Unhookable")
            ropeGun.BreakRope();

        if (_fixedJoint is null && ropeGun.ropeState == RopeState.Fly)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
            if (collision.rigidbody)
                _fixedJoint.connectedBody = collision.rigidbody;
            ropeGun.CreateSpring();
        }

    }

    public void DestroyJoint()
    {
        if (_fixedJoint)
            Destroy(_fixedJoint);
        _fixedJoint = null;
    }
}
