using UnityEngine;

public class CombatEntity : MonoBehaviour, IDamageable
{
    [SerializeField] Health health;
    class StatusEffectsHandler { };
    [SerializeField] StatusEffectsHandler statusEffectsHandler;


    private void Start()
    {
        TryGetComponent(out health);

        TryGetComponent(out statusEffectsHandler);
    }
    public bool Damage(DamageDataSO dmgData)
    {
        return true;
    }
}
