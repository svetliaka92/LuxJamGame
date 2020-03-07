using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMeter : Meter
{
    public override void UseMeter(float useValue)
    {
        _meterValue = Mathf.Clamp(useValue, 0, 100);

        base.UseMeter(useValue);
    }
}
