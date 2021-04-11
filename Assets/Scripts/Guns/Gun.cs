using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletEmitter;
    public float bulletSpeed = 30;
    public float shotPeriod = 0.1f;
    public AudioSource shotSound;
    public GameObject flash;

    private float shotTimer;

    void Update()
    {
        shotTimer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {            
            if (shotTimer > shotPeriod)
                Shoot();
        }
    }

    public virtual void Shoot()
    {
        shotTimer = 0;
        shotSound.pitch = Random.Range(0.8f, 1.2f);
        shotSound.Play();
        flash.SetActive(true);
        Invoke("HideFlash", 0.05f);
        GameObject bullet = Instantiate(bulletPrefab, bulletEmitter.position, bulletEmitter.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletEmitter.forward * bulletSpeed;
        
    }

    public void HideFlash()
    {
        flash.transform.Rotate(new Vector3(0, 0, 70));
        flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int amount)
    { }

}
