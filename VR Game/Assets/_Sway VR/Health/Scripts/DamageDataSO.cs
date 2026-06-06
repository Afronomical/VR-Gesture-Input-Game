using UnityEngine;

[CreateAssetMenu(fileName = "DamageDataSO", menuName = "SwayVR/AttackData/DamageDataSO")]

public class DamageDataSO : ScriptableObject 
{
    [SerializeField, Tooltip("The immediate amount of damage applied to the target")]
    private int _damageVal;
    public int damageVal 
    { get { return _damageVal; } }


    [SerializeField, Tooltip("The type of damage/element of the attack")]
    private StatusEffectSO _statusType;
    public StatusEffectSO statusType 
    {  get { return _statusType; } set { _statusType = value; } }


    [SerializeField, Tooltip("The amount of x element added by this attack. Ex: +3 Burn")]
    private int _statusStacksAdded = 1;
    private int statusStacksAdded 
    {  get { return _statusStacksAdded; } set { _statusStacksAdded = value; } }


    [SerializeField, Tooltip("How long an object damaged by this gets stunned for")]
    private float _hitStun = 0.0f;
    public float hitStun 
    { get { return _hitStun; } }


    [SerializeField, Tooltip("The amount of knockback this attack applies to the target")]
    private float _hitStrength = 0.0f;
    public float hitStrength 
    { get { return _hitStrength; } }

    //new conventions as I'm messing around with Getters and setters
}
