using UnityEngine;

public interface IDamageable
{
    bool DamageHP(int damage);
    bool DamageHP(int damageToSubtract, EStatusEffectType statusDamage, float buildUpAmount);
}
