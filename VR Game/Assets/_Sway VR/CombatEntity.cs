using UnityEngine;

public class CombatEntity : MonoBehaviour, IDamageable
{
    [SerializeField] Health health;
    class StatusEffectsHandler { };
    [SerializeField] StatusEffectsHandler statusEffectsHandler;

    public bool Damage(DamageDataSO dmgData)
    {
        return true;
    }
}
