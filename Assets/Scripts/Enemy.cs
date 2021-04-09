using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Player target;
    public int contactDamageValue = 1;
    public float attackPeriod = 5;
    public GameObject destroyEffect;

    public void Start()
    {
        FindTarget();
    }

    protected void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            MakeDamage(player.gameObject);
        }
    }

    public static void RemoveAll()
    {
        foreach (Enemy enemy in FindObjectsOfType<Enemy>())
            Destroy(enemy.gameObject);
        target = null;
    }

    protected bool FindTarget()
    {
        if (target is null)
            target = FindObjectOfType<Player>();
        if (target is null)
            return false;
        return true;
    }

    private void MakeDamage(GameObject gameObject)
    {
        Health health = gameObject.GetComponentInParent<Health>();
        if (health)
            health.TakeDamageAndInvulnerate(contactDamageValue);
    }

    public void Die()
    {
        if (destroyEffect)
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
