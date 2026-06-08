using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class Projectile :  MonoBehaviour
{
    public GameObject hitParticle;
    public GameObject damagePopUp;
    public Vector3 dmgPopUpOffset;
    public DamageDataSO damageData;

    

}
