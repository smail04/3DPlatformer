using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject healthIconPrefab;
    public List<GameObject> healthIcons = new List<GameObject>();
    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
            healthIcons.Add(Instantiate(healthIconPrefab, transform));
    }

    public void UpdateHealthIcons(int currentHealth)
    {
        healthIcons.ForEach((icon) => icon.SetActive(false));
        for (int i = 0; i < currentHealth; i++)
            healthIcons[i].SetActive(true);
    }

}
