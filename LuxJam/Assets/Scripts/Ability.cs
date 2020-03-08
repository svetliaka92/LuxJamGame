using UnityEngine;

public class Ability : MonoBehaviour
{
    public AbilityType aType;
    public bool canCast = true;

    [SerializeField] protected int[] chargeStages = { 0, 1, 2, 3, 4, 5 };
    [SerializeField] protected int[] stageDurations = { 5, 8, 11, 14, 17, 20 };
    [SerializeField] protected float[] aLightCosts = { 2, 4, 8, 13, 16, 20 };
    [SerializeField] protected float[] aFatigueCosts = { 2, 4, 9, 15, 21, 27 };

    protected int chargeStage = 0;

    protected AbilityManager manager;

    public void Init(AbilityManager manager)
    {
        this.manager = manager;
    }

    public virtual float GetAbilityCost(float timer)
    {
        for (int i = chargeStages.Length - 1; i >= 0; i--)
        {
            if (timer >= chargeStages[i])
            {
                chargeStage = i;
                return aLightCosts[i];
            }
        }

        return 0f;
    }

    public virtual float GetAbilityFatigueCost(float timer)
    {
        return aFatigueCosts[chargeStage];
    }

    public void Cast(float timer)
    {
        // cast ability
        // send ability + stage to player buff manager
        canCast = false;

        manager.OnAbilityCast(aType, stageDurations[chargeStage], aFatigueCosts[chargeStage]);
    }

    public void OnAbilityCD()
    {
        canCast = true;
    }
}
