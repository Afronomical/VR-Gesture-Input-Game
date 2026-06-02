using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class Projectile :  Hitbox
{
    public float damage = 1f;
    public float hitstun = 0.5f;
    public float launchSpeed = 10f;
    public Vector3 launchDirection = Vector3.forward;

}
