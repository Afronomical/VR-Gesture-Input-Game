using System.Linq;
using UnityEngine;

public class SphereTestHitbox : MonoBehaviour
{

    public GameObject hitParticle;
    public float damageTotal = 5;


    private void OnCollisionEnter(Collision collision)
    {
        GameObject GO = collision.gameObject;
        if (GO.GetComponent<IDamageable>() != null)
        {
            GO.GetComponent<IDamageable>().DamageHP(damageTotal);
        }
        


        Instantiate(hitParticle, collision.contacts[0].point, Quaternion.FromToRotation(gameObject.transform.position, collision.gameObject.transform.position) );

        
        
    }

    private void Update()
    {
       
    }
}
