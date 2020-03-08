using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI meterText;
    [SerializeField] private Image meterbar;

    public void UpdateMeter(float value)
    {
        meterText.text = value.ToString("F0");
        meterbar.fillAmount = (value / 100f);
    }
}
