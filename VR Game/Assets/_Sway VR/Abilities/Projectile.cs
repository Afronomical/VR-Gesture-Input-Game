using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class Projectile :  Hitbox
{
    public GameObject hitParticle;
    public GameObject damagePopUp;
    public Vector3 dmgPopUpOffset;
    public DamageDataSO damageData;
/*    public StatusDataSO effectDataSO;
    public StatusEffectData effectData = new StatusEffectData();*/
    

}
