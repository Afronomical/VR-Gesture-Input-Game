using UnityEngine;

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
        statusEffectsHandler.ApplyEffect(dmgData.statusType, dmgData.statusStacks);

        return health.DamageHP(dmgData.damageVal);
    }
}
