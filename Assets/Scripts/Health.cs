using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int startHealth;
    public float invulnerabilityTimeAfterDamage = 1;
    public HealthUI healthUI;
    public UnityEvent OnDie;
    public UnityEvent OnTakingDamage;
    public UnityEvent OnAddHealth;    
    private bool invulnerable;
    private int currentHealth;

    public int CurrentHealth
    {
        get => currentHealth;
        set
        {
            currentHealth = value;
            if (healthUI)
                healthUI.UpdateHealthIcons(value);
        }
    }


    private void Start()
    {
        currentHealth = startHealth;
        if (healthUI)
        {
            healthUI.Setup(maxHealth);
            healthUI.UpdateHealthIcons(CurrentHealth);
        }
    }

    public void TakeDamage(int damageValue)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damageValue, 0, maxHealth);
        OnTakingDamage.Invoke();
        if (CurrentHealth <= 0)
            OnDie.Invoke();
    }
    
    public void TakeDamageAndInvulnerate(int damageValue)
    {
        if (!invulnerable)
            TakeDamage(damageValue);
        invulnerable = true;
        Invoke("StopInvulnerability", invulnerabilityTimeAfterDamage);
    }

    private void StopInvulnerability()
    {
        invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + healthValue, 0, maxHealth);
        OnAddHealth.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet)
            {
                TakeDamage(bullet.GetDamage());
            }
        }

    }

}
