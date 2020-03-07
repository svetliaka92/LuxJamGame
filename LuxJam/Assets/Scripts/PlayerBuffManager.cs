using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerBuffManager : MonoBehaviour
{
    private PlayerController _controller;
    private List<Buff> activeBuffs = new List<Buff>();

    public void Init(PlayerController controller)
    {
        _controller = controller;
    }

    public void AddBuff(AbilityType type, float duration)
    {
        Buff buff = new Buff(type, duration);
        buff.onBuffExpire += OnBuffExpire;
        buff.Start();

        activeBuffs.Add(buff);

        if (type == AbilityType.shield)
            _controller.UpdateShieldState(true);
    }

    private void OnBuffExpire(AbilityType type)
    {
        _controller.OnAbilityExpire(type);

        if (type == AbilityType.shield)
            _controller.UpdateShieldState(false);
    }

    private void Update()
    {
        foreach (Buff buff in activeBuffs)
            buff.Tick();
    }
}
