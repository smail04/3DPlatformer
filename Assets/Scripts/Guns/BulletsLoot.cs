using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsLoot : MonoBehaviour
{
    public int gunIndex;
    public int bulletsAmount;
    private bool _active = true;//Это защита от двойного срабатывания лута. Была такая проблема. Возможно,
                                //из-за нескольких коллайдеров на плеере.

    private void OnTriggerEnter(Collider other)
    {
        if (!_active)
            return;

        PlayerArmory armory = other.gameObject.GetComponentInParent<PlayerArmory>();
        if (armory)
        {
            _active = false;
            Destroy(gameObject);
            armory.AddBullets(gunIndex, bulletsAmount);
        }
    }
}
