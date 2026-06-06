using UnityEngine;
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Fireball_Projectile : Projectile
{
    Rigidbody rb;
    Vector3 moveDirection;
    [SerializeField] float moveForce = 5f;
    [SerializeField] GameObject impactFX;


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
            if (GO.GetComponent<IDamageable>().DamageHP(damageData.damageVal, EStatusEffectType.burn, 10))
            {
                GameObject popUp = Instantiate(damagePopUp, collision.contacts[0].point + dmgPopUpOffset, Quaternion.identity);
                popUp.GetComponent<DamagePopUpTextUpdater>().UpdateDamageText(damageData.damageVal);
                popUp.GetComponent<DamagePopUpTextUpdater>().UpdateColour((damageData.statusType != null)?damageData.statusType.Color : Color.white);
                Instantiate(impactFX, collision.contacts[0].point, Quaternion.FromToRotation(gameObject.transform.position, collision.gameObject.transform.position));
                Destroy(gameObject);

            }
            
        }
        
    }
}
