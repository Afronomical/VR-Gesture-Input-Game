using System;
using UnityEngine;
using System.Collections.Generic;


public class Health : MonoBehaviour, IDamageable
{
    //The health of the object at this given moment
    [SerializeField]float currentHP;

    //CurrentHP should never really go above this value
    float maxHP;

    bool isDead = false;
    bool deadLastFrame = false;

    //Each source of damage done to the player this frame
    public List<float> ListOfDamageSources;

    //Dummy class
   /* public class DamageType {


        //Should account for all factors that might be necessary when calculating damage
        //This includes: 
        *//*
            Dealer
            Strength
            PhysicalType
            ElementalType
            FinalOutput
         *//*

        float damageValue;
        float damageType;
        float element;

        public float finalDamage;
    };*/

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

    //Check the state of the object. Was it hit or died this frame. Announces to all listeners
    public event Action OnHarmed;

    public event Action OnDeath;

    public event Action OnHealed;



    private void Start()
    {
        //Functions to test if events work accordingly

        /*OnDeath += DeathCall;
        OnHarmed += HitCall;*/
    }
    private void Update()
    {
        ForceHealthValuesInRange();
        UpdateDeathState();
        AnnounceIfDead();
    }

   

    
    #region Death Event Management
    public bool UpdateDeathState()
    {
        if ((currentHP <= 0))
        {
            
            isDead = true;

        }
        else
        {
            isDead = false;
        }


        return isDead;
    }
    public void AnnounceIfDead()
    {
        if (isDead && !deadLastFrame)
        {
            OnDeath();
        }
        deadLastFrame = isDead;
    }
    void ForceHealthValuesInRange()
    {
        if (0 > currentHP) { currentHP = 0; }
        else if (maxHP > currentHP) { currentHP = maxHP; }

    }
    #endregion

    #region Modify Health values
    public void HealHP(float healthToAdd)
    {
        currentHP += healthToAdd;
        if(OnHealed != null) { OnHealed(); }
    }
    public void DamageHP(float damageToSubtract)
    {
        currentHP -= damageToSubtract;
        if(OnHarmed != null) OnHarmed();
        
    }
    public void SetHealth(float health)
    {
        currentHP = health;
    }
    #endregion

    #region Getters
    public float GetHealthPercentage()
    {
        if(maxHP <= 0) {  return 0; }

        return currentHP / maxHP;
    }

    public float GetCurrentHP()
    {
        return currentHP;
    }
    public float GetMaxHP()
    {
        return maxHP; 
    }
    #endregion

    void DeathCall()
    {
        Debug.Log("Has died");
    }
    void HarmedCall()
    {
        Debug.Log("Was harmed");
    }

}
