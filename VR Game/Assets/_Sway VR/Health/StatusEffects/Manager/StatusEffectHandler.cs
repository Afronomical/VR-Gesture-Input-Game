using System;
using System.Collections.Generic;
using System.Linq;
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
    class StatusEffectDefenseSO
    {
        StatusEffectSO typeResistance;
        float stackReductionMultiplier = 1;
        float stackActivationThreshold;
        float stacksLostEverySecond;
    }
public class StatusEffectHandler : MonoBehaviour
{
    public Dictionary<StatusEffectSO, int> effectInstances = new();

    [SerializeReference]
    public HashSet<StatusEffectSO> enabledEffects = new();

    [SerializeField,Tooltip("The speed at which update is called, each time an effect is applied")] 
    const float tickSpeed = 1f;
    [SerializeField] float currentTick = 0f;
    [SerializeField] float lastTick = 0f;

    [SerializeField] int stackThreshold = 5;


    public event Action <StatusEffectSO> OnStatusActivate;
    public event Action <StatusEffectSO> OnStatusDeactivate;
    public event Action <StatusEffectSO, int, int> OnUpdateStatusInfo;

    public int GetStacks(StatusEffectSO statusQuery)
    {
        return effectInstances.TryGetValue(statusQuery, out int stacks) ? stacks: 0;
    }
    public int GetStackThreshold(StatusEffectSO statusQuery)
    {
        return stackThreshold;
    }
    public float GetStackPercentage(StatusEffectSO statusQuery)
    {
        return (float)effectInstances[statusQuery]/stackThreshold;
    }
    public void ApplyEffect(StatusEffectSO statusEffect, int numStacks)
    {
       
        if (effectInstances.ContainsKey(statusEffect))
        {
            effectInstances[statusEffect] += numStacks;
        }
        else
        {
            effectInstances.Add(statusEffect, numStacks);
        }
        
        if (effectInstances[statusEffect] >= stackThreshold )
        {
            
            if (!enabledEffects.Contains(statusEffect))
            {

                enabledEffects.Add(statusEffect);

                ActivateEffect(statusEffect);
            }
        }
        OnUpdateStatusInfo?.Invoke(statusEffect, effectInstances[statusEffect], stackThreshold);
    }
    public void ClearEffect(StatusEffectSO statusEffect)
    {
        if (effectInstances.ContainsKey(statusEffect))
        {
            effectInstances[(statusEffect)] = 0;
            effectInstances.Remove(statusEffect);
        }
    }
    public void RemoveEffect(StatusEffectSO statusEffect, int numStacks)
    {
        if (effectInstances.ContainsKey(statusEffect))
        {
            effectInstances[(statusEffect)] -= numStacks;
        }
        if(effectInstances[(statusEffect)] <= 0)
        {
            ClearEffect(statusEffect);
        }
    }
    public void ActivateEffect(StatusEffectSO statusEffect)
    {
        if (effectInstances.ContainsKey(statusEffect))
        {
            statusEffect.OnActivate(this);
            OnStatusActivate?.Invoke(statusEffect);

            if (OnStatusActivate != null) { OnStatusActivate(statusEffect); }
            else { Debug.LogWarning(" Event 'OnStatusActivate' has no listeners "); }
        }
    }
    public void UpdateTick()
    {
        
        foreach (StatusEffectSO item in enabledEffects.ToList())
        {
                
            if (effectInstances[item] > 1)
            {
                item.OnTick(this);
                effectInstances[item]-=1;  
                OnUpdateStatusInfo?.Invoke(item, effectInstances[item],stackThreshold);
            }
            else
            {
                effectInstances[item] = 0;
                item.OnDeactivate(this);
                enabledEffects.Remove(item);
                OnStatusDeactivate?.Invoke(item);
            }
        }
    }
    private void Update()
    {

        currentTick += Time.deltaTime;
        if (currentTick > tickSpeed)
        {
            UpdateTick();
            currentTick = 0;
        }
    }

}
