using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Renderer[] renderers;
        
    public void StartBlink()
    {
        StartCoroutine("BlinkEffect");  
    }

    private IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            SetEmissionColorForAllRenderers(new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));
            yield return null;
        }
        SetEmissionColorForAllRenderers(new Color(0, 0, 0.01f, 0));
    }

    private void SetEmissionColorForAllRenderers(Color color)
    {
        foreach (Renderer _renderer in renderers)
            foreach (Material material in _renderer.materials)
                material.SetColor("_EmissionColor", color);
    }
}
