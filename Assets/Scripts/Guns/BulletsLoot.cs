using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsLoot : MonoBehaviour
{
    public int gunIndex;
    public int bulletsAmount;
    private bool _active = true;

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
