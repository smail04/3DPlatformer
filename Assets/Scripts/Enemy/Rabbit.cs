using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : ShooterEnemy
{
    private new void Update()
    {
        base.Update();
        if (FindTarget())
        {
            Vector3 toTarget = target.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, ((toTarget.x > 0) ? 20 : 160), 0), Time.deltaTime * 15);
        }
    }


}
