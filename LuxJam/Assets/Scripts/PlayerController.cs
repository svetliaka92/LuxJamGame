using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LightMeter lightMeter;
    [SerializeField] private ShadowMeter shadowMeter;
    [SerializeField] private FatigueMeter fatigueMeter;
    [SerializeField] private PainMeter painMeter;

    [SerializeField] private Inventory inventory;
    [SerializeField] private AbilityManager abilityManager;

    [SerializeField] private FirstPersonController controller;
    [SerializeField] private PlayerBuffManager _playerBuffManager;

    private bool _isInLight = false;
    private bool _canCast = false;
    private bool _isShielded = false;

    private bool isDead = false;

    private void Start()
    {
        if (controller)
            controller.UpdateMaxSpeed(painMeter.MeterValue);

        inventory.onItemUse += OnShardUse;
        abilityManager.onAbilityCastEvent += OnAbilityUse;

        _playerBuffManager.Init(this);

        isDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        LightPoint post = other.GetComponentInParent<LightPoint>();
        if (other.tag == "LightPoint" && post != null && post.isEnabled)
            _isInLight = true;
        else if (other.tag == "ShadePoint")
            UpdateShadeState(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "LightPoint")
            _isInLight = false;
        else if (other.tag == "ShadePoint")
            UpdateShadeState(false);
    }

    private void Update()
    {
        if (isDead
            || GameManager.Instance.IsPaused)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.PauseGame();

        UpdateMeters();

        controller.Tick();
    }

    private void FixedUpdate()
    {
        if (isDead
            || GameManager.Instance.IsPaused)
            return;

        controller.FixedTick();
    }

    public void UpdateInLight(bool flag)
    {
        _isInLight = flag;
    }

    private void UpdateMeters()
    {
        if (_isInLight)
        {
            lightMeter.IncreaseMeter();
            shadowMeter.DecreaseMeter();

            fatigueMeter.DecreaseMeter();
        }

        if (!_isInLight && !_isShielded)
        {
            shadowMeter.IncreaseMeter();

            CheckShadowMeter();
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.T))
        {
            lightMeter.Test();
            shadowMeter.Test();
            fatigueMeter.Test();
            painMeter.Test();
        }
#endif
    }

    public void UpdateShadeState(bool flag)
    {
        shadowMeter.UpdateIsInShade(flag);

        _canCast = !flag;
        abilityManager.UpdateCanCastState(_canCast);
    }

    internal void UpdateShieldState(bool flag)
    {
        _isShielded = flag;
    }

    private void OnShardUse(ShardType shartType)
    {
        if (shartType == ShardType.small)
        {
            float newMeter = lightMeter.MeterValue + 25f;
            lightMeter.UseMeter(newMeter);

            CheckForPain(10);

            fatigueMeter.UseMeter(10);
        }
        else if (shartType == ShardType.medium)
        {
            float newMeter = lightMeter.MeterValue + 50f;
            lightMeter.UseMeter(newMeter);

            CheckForPain(20);

            fatigueMeter.UseMeter(20);
        }
        else if (shartType == ShardType.large)
        {
            float newMeter = lightMeter.MeterValue + 100f;
            lightMeter.UseMeter(newMeter);

            CheckForPain(30);

            fatigueMeter.UseMeter(30);
        }
    }

    private void CheckShadowMeter()
    {
        if (shadowMeter.MeterValue >= 100)
        {
            isDead = true;
            controller.UpdateIsDead(isDead);
            GameManager.Instance.LoseGame();
        }
    }

    private void OnAbilityUse(AbilityType type, float duration, float fatigue)
    {
        _playerBuffManager.AddBuff(type, duration);
        CheckForPain(fatigue);
    }

    public void OnAbilityExpire(AbilityType type)
    {
        abilityManager.OnAbilityExpire(type);
    }

    private void CheckForPain(float fatigueIncrease)
    {
        float fatigueOverflow = (fatigueMeter.MeterValue + fatigueIncrease) - 100;
        if (fatigueOverflow > 0)
            painMeter.UseMeter(fatigueOverflow);

        OnPainMeterUpdate();
    }

    private void OnPainMeterUpdate()
    {
        if (controller)
            controller.UpdateMaxSpeed(painMeter.MeterValue);
    }
}
