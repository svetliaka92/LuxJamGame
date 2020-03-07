using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatigueMeter : Meter
{
    public override void UseMeter(float useValue)
    {
        _meterValue = Mathf.Clamp(_meterValue + useValue, 0, 100);

        base.UseMeter(useValue);
    }
}
