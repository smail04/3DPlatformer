using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeEffect : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator.Play("Poof");
    }
    public void Remove()
    {
        Destroy(gameObject);
    }
}
