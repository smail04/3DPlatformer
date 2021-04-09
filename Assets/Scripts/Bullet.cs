using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effectPrefab;

    private int damageValue;

    private void Awake()
    {
        damageValue = Random.Range(1, 3);      
    }

    void Start()
    {
        effectPrefab.transform.localScale = Vector3.one * 0.5f;
    }

    void Update()
    {
        Destroy(gameObject, 3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(effectPrefab, collision.contacts[0].point, Quaternion.identity);
        Destroy(gameObject);
    }

    public int GetDamage()
    {
        return damageValue;
    }
}
