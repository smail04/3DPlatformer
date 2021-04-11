using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public float force;
    public PlayerArmory armory;
    public float maxCharge;
    public ChargeIcon chargeIcon;
    private float currentCharge;
    private bool isCharged = true;
    
    private void Update()
    {
        if (isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _rigidbody.AddForce(-transform.forward * force, ForceMode.VelocityChange);
                armory.guns[armory.currentGunIndex].Shoot();
                isCharged = false;
                currentCharge = 0;
                chargeIcon.StartCharge();
            }
        }
        else
        {
            currentCharge += Time.deltaTime;
            chargeIcon.SetChargeValue(currentCharge, maxCharge);
            if (currentCharge >= maxCharge)
            {
                isCharged = true;
                chargeIcon.StopCharge();
            }
        }
        
    }
}
