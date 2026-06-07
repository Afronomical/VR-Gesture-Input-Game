using UnityEngine;

//public enum EStatusEffectType { burn, wet, frozen, shock }

[CreateAssetMenu(fileName = "BurnStatusEffectSO", menuName = "SwayVR/StatusEffects/BurnStatusEffectSO")]

public class BurnStatusEffectSO : StatusEffectSO
{
    CombatEntity target;
    [SerializeField] DamageDataSO burnDamagePerTick;


    public override void OnActivate(StatusEffectHandler handler)
    {
        target = handler.GetComponent<CombatEntity>();
        
    }
    public override void OnTick(StatusEffectHandler handler)
    {
        target = handler.GetComponent<CombatEntity>();
        target.Damage(burnDamagePerTick);
    }
    public override void OnDeactivate(StatusEffectHandler handler)
    {
        target = handler.GetComponent<CombatEntity>();
        Debug.Log("Deactivated");
    }




}
