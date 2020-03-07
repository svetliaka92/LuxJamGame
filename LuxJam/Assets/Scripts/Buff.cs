using System;
using UnityEngine;

class Buff
{
    private AbilityType buffType;

    private float timer = 0f;
    private float duration = 0f;

    private bool canTick = false;

    public event Action<AbilityType> onBuffExpire;

    public Buff(AbilityType type, float duration)
    {
        buffType = type;
        this.duration = duration;
    }

    public void Start()
    {
        canTick = true;
    }

    public void Tick()
    {
        if (!canTick)
            return;

        timer += Time.deltaTime;

        if (timer >= duration)
            Expire();
    }

    private void Expire()
    {
        canTick = false;

        onBuffExpire?.Invoke(buffType);
    }
}
