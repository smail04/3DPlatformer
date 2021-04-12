using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : ShooterEnemy
{ 
    private new void Update()
    {
        base.Update();
        if (FindTarget())
        {
            Vector3 toTarget = target.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, ((toTarget.x > 0) ? 10 : 170), 0), Time.deltaTime * 15);
        }
    }

    public void TakeDamageAnimation()
    {
        animator.SetTrigger("Damage");
    }

}
