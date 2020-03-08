using System;
using UnityEngine;

class Buff
{
    private AbilityType buffType;

    private float timer = 0f;
    private float duration = 0f;

    private bool canTick = false;

    public float percentDuration;
    public event Action<AbilityType> onBuffExpire;

    public Buff(AbilityType type, float duration)
    {
        buffType = type;
        this.duration = duration;
    }

    public void Start()
    {
        timer = 0f;
        canTick = true;
    }

    public void Tick()
    {
        if (!canTick)
            return;

        timer += Time.deltaTime;
        percentDuration = timer / duration;

        if (timer >= duration)
            Expire();
    }

    private void Expire()
    {
        canTick = false;

        onBuffExpire?.Invoke(buffType);
    }
}
