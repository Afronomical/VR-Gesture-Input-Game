using UnityEngine;

[CreateAssetMenu(fileName = "DamageDataSO", menuName = "CombatSystem/DamageDataSO")]

public class DamageDataSO : ScriptableObject 
{
    [Tooltip("The immediate amount of damage applied to the target")]
    public int damage;
    [Tooltip("The type of damage/element of the attack")]
    public int type;
    [Tooltip("Chance this damage source will inflict a status effect on the target")]
    [Range(0,100)]public int statusChance;

    [Tooltip("how long an object damaged by this gets stunned for")]
    public float hitStun = 0.0f;

}
