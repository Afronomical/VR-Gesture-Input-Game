using UnityEngine;
[RequireComponent(typeof(Health)), RequireComponent(typeof(StatusEffectHandler))]
public class CombatEntity : MonoBehaviour, IDamageable
{
    [SerializeField] Health health;
    
    [SerializeField] StatusEffectHandler statusEffectsHandler;


    private void Start()
    {
        TryGetComponent(out health);

        TryGetComponent(out statusEffectsHandler);
    }
    public bool Damage(DamageDataSO dmgData)
    {
        if(dmgData.statusType != null) { statusEffectsHandler.ApplyEffect(dmgData.statusType, dmgData.statusStacks); }
            

        return health.DamageHP(dmgData.damageVal);
    }
}
