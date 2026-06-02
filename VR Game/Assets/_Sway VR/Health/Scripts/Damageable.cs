using UnityEngine;

public class Damageable : Health, IDamageable
{
    StatsData stats;


    public bool DamageHP(int damage)
    {
        return true;
    }

}
