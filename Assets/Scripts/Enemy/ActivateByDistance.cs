using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    public float distanceToActivate = 15;
    private bool _isActive = true;
    private Activator _activator;

    public Activator Activator { 
        get 
        {
            if (!_activator)
                _activator = FindObjectOfType<Activator>();
            return _activator; 
        } 
        set => _activator = value; }

    private void Start()
    {
        if (Activator) 
            Activator.objectsToActivate.Add(this);    
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (_isActive)
        {
            if (distance > distanceToActivate + 2)
                Deactivate();
        }
        else
            if (distance < distanceToActivate)
            Activate();
    }

    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (Activator)
            Activator.objectsToActivate.Remove(this);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.DrawWireDisc(transform.position, Vector3.forward, distanceToActivate);
    }
#endif
}
