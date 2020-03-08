using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour
{
    [SerializeField] private MeterUI _meterUI;

    [SerializeField] protected float _gainSpeed = 1;
    [SerializeField] protected float _loseSpeed = 1;

    protected float _meterValue = 0f;
    public float MeterValue => _meterValue;

    public virtual void IncreaseMeter()
    {
        _meterValue = Mathf.Clamp(_meterValue + _gainSpeed * Time.deltaTime, 0, 100);

        UpdateMeterUI();
    }

    public virtual void DecreaseMeter()
    {
        _meterValue = Mathf.Clamp(_meterValue - _loseSpeed * Time.deltaTime, 0, 100);

        UpdateMeterUI();
    }

    public virtual void UseMeter(float useValue)
    {
        UpdateMeterUI();
    }

    public void SetTo(float value)
    {
        _meterValue = Mathf.Clamp(value, 0, 100);

        UpdateMeterUI();
    }

    public void Test()
    {
        _meterValue = 90;

        UpdateMeterUI();
    }

    private void UpdateMeterUI()
    {
        _meterUI.UpdateMeter(_meterValue);
    }
}
