using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    public Gun[] guns;
    public int currentGunIndex = 0;

    private void Start()
    {
        TakeGunByIndex(currentGunIndex);
    }

    public void TakeGunByIndex(int index)
    {
        if (index > guns.Length-1)
            index = 0;

        foreach (Gun gun in guns)
            gun.Deactivate();

        guns[index].Activate();

        currentGunIndex = index;

    }

}
