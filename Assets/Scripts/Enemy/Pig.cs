using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection { 
    Right, Left
}

public class Pig : Enemy
{
    public Transform LPoint, RPoint;
    public Transform head;
    public Transform rayStart;
    public Animator animator;
    public float moveSpeed = 2;
    public float rotationSpeed = 10;
    public MoveDirection currentDirection = MoveDirection.Left;
    private bool isStopped;

    private void Awake()
    {
        LPoint.parent = null;
        RPoint.parent = null;
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, (currentDirection == MoveDirection.Left) ? 75 : -75, transform.rotation.z));
        head.localRotation = Quaternion.Euler(new Vector3(head.rotation.x, head.rotation.y, (currentDirection == MoveDirection.Right) ? 65 : -65));
    }

    void Update()
    {
        if (isStopped)
        {
            Rotate();
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(rayStart.position, Vector3.down, out hit))
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);   


        if (currentDirection == MoveDirection.Right)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x >= RPoint.position.x)
            {
                currentDirection = MoveDirection.Left;
                Stop();
            }
        }
        else
        {
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x <= LPoint.position.x)
            {
                currentDirection = MoveDirection.Right;
                Stop();
            }
        }
    }
    
    private void Rotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, 
                                            Quaternion.Euler(new Vector3(transform.rotation.x, (currentDirection == MoveDirection.Left) ? 75 : -75, transform.rotation.z)), 
                                            rotationSpeed * Time.deltaTime);
        head.localRotation = Quaternion.Lerp(head.localRotation,
                                            Quaternion.Euler(new Vector3(head.rotation.x, head.rotation.y, (currentDirection == MoveDirection.Right) ? 65 : -65)),
                                            rotationSpeed * Time.deltaTime);
    }

    private void Stop(float seconds = 1)
    {        
        isStopped = true;
        Invoke("ContinueWalk", seconds);
    }

    private void ContinueWalk()
    {
        isStopped = false;
    }

    public new void Die()
    {
        base.Die();
        Destroy(LPoint.gameObject);
        Destroy(RPoint.gameObject);
    }

}
