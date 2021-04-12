using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    public Animator animator;
    private float _timer;
    protected void Update()
    {
        _timer += Time.deltaTime;
        if (FindTarget())
        {
            if(Mathf.Abs(Vector3.Distance(target.transform.position, transform.position)) < 20)
                if (_timer >= attackPeriod)
                {
                    _timer = 0;
                    animator.SetTrigger("Attack");
                }
        }
    }

}
