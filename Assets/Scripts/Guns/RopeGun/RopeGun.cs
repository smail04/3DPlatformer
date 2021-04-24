using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState 
{ 
    Active, Fly, Disabled
}

public class RopeGun : MonoBehaviour
{
    public RopeRenderer ropeRenderer;
    public Transform pointer;
    public Hook hook;
    public float speed;
    public RopeState ropeState;
    private SpringJoint _springJoint;
    private float ropeLength;
    private bool isRopeBreaked;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ropeState = RopeState.Fly;
            isRopeBreaked = false;
            Shot();
        }

        if (Input.GetMouseButtonUp(1))
        {             
            DestroySpring();
            ropeRenderer.Hide();
        }

        if (Input.GetMouseButton(1) && !isRopeBreaked)
        {
            ropeRenderer.Draw(pointer.position, hook.transform.position, ropeLength);
        }
        else
        {
            hook.transform.position = pointer.position;
            hook.rigidbody.velocity = Vector3.zero;
        }
        
            
    }

    private void Shot()
    {
        ropeLength = 0.01f;
        hook.DestroyJoint();
        hook.transform.position = pointer.position;
        hook.transform.rotation = pointer.rotation;
        hook.rigidbody.velocity = pointer.forward * speed;
    }

    public void CreateSpring()
    {
        ropeState = RopeState.Active;
        if (_springJoint is null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
            _springJoint.connectedBody = hook.rigidbody;
            _springJoint.anchor = pointer.localPosition;
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = Vector3.zero;
            ropeLength = Vector3.Distance(pointer.position, hook.transform.position);
            _springJoint.maxDistance = ropeLength;
            _springJoint.spring = 200;
            _springJoint.damper = 10;
        }
    }

    public void DestroySpring()
    {
        ropeState = RopeState.Disabled;
        if (_springJoint)
            Destroy(_springJoint);
        _springJoint = null;
    }

    public void BreakRope()
    {
        isRopeBreaked = true;
        DestroySpring();
        ropeRenderer.Hide();
    }
}
