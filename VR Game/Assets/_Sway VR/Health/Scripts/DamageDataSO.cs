using UnityEngine;

[CreateAssetMenu(fileName = "DamageDataSO", menuName = "CombatSystem/DamageDataSO")]
public class DamageDataSO : ScriptableObject 
{
    [Tooltip("The immediate amount of damage applied to the target")]
    public float damage;
    [Tooltip("The type of damage/element of the attack")]
    public int type;
    [Tooltip("Chance this damage source will inflict a status effect on the target")]
    [Range(0,100)]public int statusChance;

}
