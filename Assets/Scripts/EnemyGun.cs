using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject spawningPrefab;
    public Transform spawnPoint;

    public void Create()
    {
        Instantiate(spawningPrefab, new Vector3(spawnPoint.position.x, spawnPoint.position.y, 0), spawnPoint.rotation);
    }
}
