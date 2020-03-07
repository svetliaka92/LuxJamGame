using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI meterText;

    public void UpdateMeter(float value)
    {
        meterText.text = value.ToString("F0");
    }
}
