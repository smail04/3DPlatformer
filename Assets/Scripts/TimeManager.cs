using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timeScale = 0.2f;
    private float startFixedDeltaTime;

    private void Start()
    {
        startFixedDeltaTime = Time.fixedDeltaTime;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = timeScale;
        }
        else
        {
            Time.timeScale = 1;
        }

        Time.fixedDeltaTime = startFixedDeltaTime * Time.timeScale;
    }
}
