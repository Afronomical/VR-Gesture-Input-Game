using UnityEngine;
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Fireball_Projectile : Projectile
{
    Rigidbody rb;
    Vector3 moveDirection;
    [SerializeField] float moveForce = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * moveForce * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject GO = collision.gameObject;
        if (GO.GetComponent<IDamageable>() != null)
        {
            if (GO.GetComponent<IDamageable>().DamageHP(damage))
            {
                GameObject popUp = Instantiate(damagePopUp, collision.contacts[0].point + dmgPopUpOffset, Quaternion.identity);
                popUp.GetComponent<DamagePopUpTextUpdater>().UpdateDamageText(damage);
                popUp.GetComponent<DamagePopUpTextUpdater>().UpdateColour(dmgColour);
                
            }
            Destroy(gameObject);
        }
        
    }
}
