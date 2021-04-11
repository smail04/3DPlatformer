using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rifle : Gun
{
    [Header("Rifle")]
    public int numberOfBullets;
    public Text bulletsText;
    public PlayerArmory armory;

    public override void Shoot()
    {
        base.Shoot();
        numberOfBullets--;
        if (numberOfBullets == 0)
        {
            armory.TakeGunByIndex(0);
        }
        UpdateText();
        
    }

    public override void Activate()
    {
        base.Activate();
        bulletsText.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        bulletsText.enabled = false;
    }

    private void UpdateText()
    {
        bulletsText.text = "Bullets: " + numberOfBullets.ToString();
    }

    public override void AddBullets(int amount)
    {
        numberOfBullets += amount;
    }
}
