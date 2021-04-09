using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingLoot : MonoBehaviour
{
    public int healthValue;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponentInParent<Player>();
        if (player)
        {
            Destroy(gameObject);
            player.GetComponent<Health>().AddHealth(healthValue);
        }
    }
}
