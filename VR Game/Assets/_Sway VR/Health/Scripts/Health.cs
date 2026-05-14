using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    //The health of the object at this given moment
    [SerializeField]float currentHP;

    //CurrentHP should never really go above this value
    float maxHP;

    //Dummy class
    public class Damage {


        //Should account for all factors that might be necessary when calculating damage
        //This includes: 
        /*
            Dealer
            Strength
            PhysicalType
            ElementalType
            FinalOutput
         */

        float damageValue;
        float damageType;
        float element;

        public float finalDamage;
    };

    /* Health allows objects to withstand damage. Any object that can be harmed needs health
     I'll need to track how much health the owner has, how much health they should have.
    Call special logic when they reach 0 health (Death)
    Possibly have events for when they gain or lose health aswell.

    Damage is more than just a number so the health system will need to receive data from a damage data object
    Health shouldn't be too complicated a class. It should exclusively handle incoming damage, after calculation and 
    act as an event system for the different states a "health" derriving object can be in

    Damage calc should be in a calculation class and health UI should refer to the health object but not influence it.
    Health is a basic container for information

    Naturally will need functions for all health data so that it is never adjusted or affected manually.
     */

    public static event Action OnDeath;

    private void Update()
    {
        SetHealthValuesInRange();
    }
    public void SetHealth(float health)
    {
        currentHP = health;
    }
    void AddHealth(float healthToAdd)
    {
        currentHP += healthToAdd;
    }
    void SetHealthValuesInRange()
    {
        if (0 > currentHP) { currentHP = 0; }
        if (maxHP > currentHP) { currentHP = maxHP; }
    }
    public void DamageObject(Damage damage)
    {
        AddHealth(damage.finalDamage);
    }

}
