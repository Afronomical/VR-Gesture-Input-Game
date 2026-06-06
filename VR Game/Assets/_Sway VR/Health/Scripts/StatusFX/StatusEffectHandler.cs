using System.Collections.Generic;
using UnityEngine;

public struct StatusEffectInstance
{
    StatusEffectSO statusEffect;
    int stacks;
    StatusEffectInstance(StatusEffectSO statusEffect,int stacks)
    {
        this.statusEffect = statusEffect;
        this.stacks = stacks;
    }
}
public class StatusEffectHandler : MonoBehaviour
{
    public Dictionary<StatusEffectSO, int> effectInstances;
    public List<StatusEffectSO> enabledEffects;

    [SerializeField,Tooltip("The speed at which update is called, each time an effect is applied")] 
    float tickSpeed = 0.1f;
    [SerializeField] float currentTick = 0f;
    [SerializeField] float lastTick = 0f;

    [SerializeField] int stackThreshold = 5;
    
    public void ApplyEffect(StatusEffectSO statusEffect, int numStacks)
    {
        if (effectInstances.ContainsKey(statusEffect))
        {
            effectInstances[statusEffect] = numStacks;
        }
        else
        {
            effectInstances.Add(statusEffect, numStacks);
        }
        if (effectInstances[statusEffect] >= stackThreshold)
        {
            enabledEffects.Add(statusEffect);
        }
    }
    public void ClearEffect(StatusEffectSO statusEffect)
    {
        if (effectInstances.ContainsKey(statusEffect))
        {
            effectInstances[(statusEffect)] = 0;
        }
    }
    public void ActivateEffect(StatusEffectSO statusEffect)
    {

    }
    public void UpdateTick()
    {
        foreach (StatusEffectSO item in enabledEffects)
        {
            item.OnTick(this);
        }
    }
    private void Update()
    {
        currentTick += Time.deltaTime;
        if (currentTick > tickSpeed + lastTick)
        {
            UpdateTick();
            lastTick = currentTick;
        }
    }

}
