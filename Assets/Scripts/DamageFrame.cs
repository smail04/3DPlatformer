using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFrame : MonoBehaviour
{
    public Image frame;
    public void Show()
    {
        StartCoroutine("ShowFrame");
    }

    IEnumerator ShowFrame()
    {
        frame.enabled = true;
        for (float t = 1; t > 0; t -= Time.deltaTime)
        {
            frame.color = new Color(frame.color.r, frame.color.g, frame.color.b, t);
            yield return null;
        }
        frame.enabled = false;
    }
}
