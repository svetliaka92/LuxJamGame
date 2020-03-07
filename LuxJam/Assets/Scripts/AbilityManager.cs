using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private BuffUI buffUI;
    [SerializeField] private Meter lightMeter;
    [SerializeField] private Meter fatigueMeter;
    [SerializeField] private Ability currentAbility;

    public event Action<AbilityType, float, float> onAbilityCastEvent;

    private float heldTime = 0;

    private bool isMouseHeld = false;
    private float lightValue = 0f;
    private float fatigueValue = 0f;

    private bool _canCast = true;

    private void Awake()
    {
        currentAbility.Init(this); // do this for all abilities when made
    }

    void Update()
    {
        if (!_canCast)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            lightValue = lightMeter.MeterValue;
            fatigueValue = fatigueMeter.MeterValue;

            isMouseHeld = true;
            ResetHeldTime();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMouseHeld = false;

            if (heldTime > 0)
                currentAbility.Cast(heldTime);
        }

        if (isMouseHeld && currentAbility.canCast)
            UpdateHoldTimer();
    }

    private void UpdateHoldTimer()
    {
        float aCost = currentAbility.GetAbilityCost(heldTime);
        float aFatigue = currentAbility.GetAbilityFatigueCost(heldTime);

        float light = lightValue - aCost;
        float fatigue = fatigueValue + aFatigue;

        if (light > 0)
        {
            heldTime += Time.deltaTime;

            lightMeter.SetTo(light);
            fatigueMeter.SetTo(fatigue);
        }
    }

    public void UpdateCanCastState(bool flag)
    {
        _canCast = flag;
        if (!_canCast)
        {
            isMouseHeld = false; // to prevent the held timer from resuming on exiting the shade
            ResetHeldTime();
        }
    }

    public void OnAbilityCast(AbilityType type, float duration, float fatigue)
    {
        onAbilityCastEvent?.Invoke(type, duration, fatigue);

        buffUI.OnBuffStart(type);
    }

    public void OnAbilityExpire(AbilityType type)
    {
        currentAbility.OnAbilityCD();

        buffUI.OnBuffExpire();
    }

    private void ResetHeldTime()
    {
        heldTime = 0;
    }
}
