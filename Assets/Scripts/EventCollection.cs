using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCollection : MonoBehaviour
{
    public UnityEvent[] events;

    public void StartEvent(int id)
    {
        events[id].Invoke();
    }
}
