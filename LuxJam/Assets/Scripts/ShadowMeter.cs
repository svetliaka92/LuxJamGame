using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMeter : Meter
{
    private bool isInShade = false;

    private int[] meterValues = { 0, 30, 50, 70 };
    private int[] gainValues = { 1, 2, 3, 5 };

    public override void IncreaseMeter()
    {
        base.IncreaseMeter();

        UpdateGainSpeed();
    }

    private void UpdateGainSpeed()
    {
        // 0-30 => 1
        // 30-50 => 2
        // 50-70 => 3
        // 70-100 => 5

        // in shade => *2

        for (int i = meterValues.Length - 1; i >= 0; i--)
        {
            if (_meterValue >= meterValues[i])
            {
                _gainSpeed = isInShade ? gainValues[i] * 2 : gainValues[i];
                break;
            }
        }
    }

    public void UpdateIsInShade(bool flag)
    {
        isInShade = flag;

        UpdateGainSpeed();
    }
}
