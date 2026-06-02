using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class Projectile :  Hitbox
{
    public GameObject hitParticle;
    public GameObject damagePopUp;
    public Vector3 dmgPopUpOffset;
    public int damage = 5;
    public StatusDataSO effectDataSO;
    public StatusEffectData effectData = new StatusEffectData();
    public Color dmgColour = Color.orangeRed;

}
