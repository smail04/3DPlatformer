using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingLoot : MonoBehaviour
{
    public int healthValue;
    private bool _active = true; //Это защита от двойного срабатывания лута. Была такая проблема. Возможно,
                                 //из-за нескольких коллайдеров на плеере.
    private void OnTriggerEnter(Collider other)
    {
        if (!_active)
            return;

        Player player = other.gameObject.GetComponentInParent<Player>();
        if (player)
        {
            _active = false;
            Destroy(gameObject);
            player.GetComponent<Health>().AddHealth(healthValue);
        }
    }
}
