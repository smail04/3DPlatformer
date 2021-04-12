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

    private void OnDestroy()
    {
        if (startFixedDeltaTime != 0) //Без этой проверки не фиксит неадекватное значение в Time.fixedDeltaTime, 
                                      //потому что метод отабатывет 2 раза (почему-то). И во второй раз startFixedDeltaTime равен нулю.
                                      //Из-за этого Time.fixedDeltaTime принимает значение 0.00001. Как следствие, лаги.
            Time.fixedDeltaTime = startFixedDeltaTime;
    }
}
