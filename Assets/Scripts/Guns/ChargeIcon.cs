using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    public Image background;
    public Image foreground;
    public Text text;

    public void StartCharge()
    {
        background.color = new Color(1, 1, 1, 0.2f);
        foreground.enabled = true;
        text.enabled = true;
    }

    public void StopCharge()
    {
        background.color = new Color(1, 1, 1, 1);
        foreground.enabled = false;
        text.enabled = false;
    }

    public void SetChargeValue(float currentCharge, float maxCharge)
    {
        foreground.fillAmount = currentCharge / maxCharge;
        text.text = Mathf.Ceil(maxCharge - currentCharge).ToString();
    }
}
