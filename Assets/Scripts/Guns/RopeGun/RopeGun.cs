using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeGun : MonoBehaviour
{
    public Transform pointer;
    public Hook hook;
    public float speed;
    private SpringJoint _springJoint;
    private float ropeLength;

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
            Shot();
        if (Input.GetMouseButtonUp(2))
            DestroySpring();
        if (!Input.GetMouseButton(2))
        {
            hook.transform.position = pointer.position;
            hook.rigidbody.velocity = Vector3.zero;
        }
    }

    private void Shot()
    {
        hook.DestroyJoint();
        hook.transform.position = pointer.position;
        hook.transform.rotation = pointer.rotation;
        hook.rigidbody.velocity = pointer.forward * speed;
    }

    public void CreateSpring()
    {
        if (_springJoint is null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
            _springJoint.connectedBody = hook.rigidbody;
            _springJoint.anchor = pointer.localPosition;
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = Vector3.zero;
            ropeLength = Vector3.Distance(pointer.position, hook.transform.position);
            _springJoint.maxDistance = ropeLength;
            _springJoint.spring = 100;
            _springJoint.damper = 10;
        }
    }

    public void DestroySpring()
    {
        if (_springJoint)
            Destroy(_springJoint);
        _springJoint = null;
    }
}
