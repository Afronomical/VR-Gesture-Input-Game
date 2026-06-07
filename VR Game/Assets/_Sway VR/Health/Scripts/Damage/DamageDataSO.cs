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


    [SerializeField, Tooltip("The amount of ''x'' status added by this attack. Ex: +3 Burn")]
    private int _statusStacks = 0;
    public int statusStacks 
    {  get { return _statusStacks; } set { _statusStacks = value; } }


    [SerializeField, Tooltip("How long an object damaged by this gets stunned for")]
    private float _hitStun = 0.0f;
    public float hitStun 
    { get { return _hitStun; } }


    [SerializeField, Tooltip("The amount of knockback this attack applies to the target")]
    private float _hitStrength = 0.0f;
    public float hitStrength 
    { get { return _hitStrength; } }


    [SerializeField, Tooltip("The effect that plays on impact with another object")]
    private GameObject _hitEffect;
    public GameObject hitEffect
    { get { return _hitEffect; } }


    

    //new conventions as I'm messing around with Getters and setters
}
