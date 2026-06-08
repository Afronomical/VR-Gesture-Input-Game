using System.Collections.Generic;
using UnityEngine;

public class StatusEffectsUI : MonoBehaviour
{

    [SerializeField] private StatusEffectUIInstance statusEffectTemplate;
    private Dictionary<StatusEffectSO, StatusEffectUIInstance> statusEffectUIDict = new();

    [SerializeField] StatusEffectHandler statusHandlerRef;

    private void Awake()
    {
        statusHandlerRef.OnStatusActivate += OnActivateStatus;
        statusHandlerRef.OnStatusDeactivate += OnDeactivateStatus;
        statusHandlerRef.OnUpdateStatusInfo += OnUpdateStatusEffect;
    }
    
    private void OnDestroy()
    {
        if (statusHandlerRef == null) return;

        statusHandlerRef.OnStatusActivate -= OnActivateStatus;
        statusHandlerRef.OnStatusDeactivate -= OnDeactivateStatus;
        statusHandlerRef.OnUpdateStatusInfo -= OnUpdateStatusEffect;
    }
    private StatusEffectUIInstance CreateStatusIcon(StatusEffectSO statusEffect)
    {
        if (statusEffectUIDict.ContainsKey(statusEffect))
        {
            return statusEffectUIDict[statusEffect];
        }

        StatusEffectUIInstance newStatusIcon = Instantiate(statusEffectTemplate, transform);

        newStatusIcon.icon.sprite = statusEffect.Icon;
        newStatusIcon.statusBackground.color = statusEffect.Color;
        

        statusEffectUIDict.Add(statusEffect, newStatusIcon);
        return newStatusIcon;

    }

    private void OnActivateStatus(StatusEffectSO statusEffect)
    {
        var ui = CreateStatusIcon(statusEffect);

        ui.activeStacksFill.fillAmount =(float)statusHandlerRef.GetStacks(statusEffect) / 
                                        (float)statusHandlerRef.GetStackThreshold(statusEffect);
        ui.gameObject.SetActive(true);
     
        //statusEffectUIDict[statusEffect] = statusUITemp;


    }
    private void OnDeactivateStatus(StatusEffectSO statusEffect)
    {
        if (statusEffectUIDict.TryGetValue(statusEffect, out var ui))
        {
            ui.gameObject?.SetActive(false);
        }
    }
    private void OnUpdateStatusEffect(StatusEffectSO statusEffect, int stacks, int threshold)
    {
        if (statusEffectUIDict.TryGetValue(statusEffect, out var ui))
        {
            ui.targetStacksFillAmount =
                statusHandlerRef.GetStackPercentage(statusEffect);
        }
    }
    private void Update()
    {
        
    }
}
