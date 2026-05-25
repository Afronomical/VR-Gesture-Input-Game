using UnityEngine;

public class SphereTestHitbox : MonoBehaviour
{

    public float damageTotal = 5;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject GO = collision.gameObject;
        if (GO.GetComponent<IDamageable>() != null)
        {
            GO.GetComponent<IDamageable>().DamageHP(damageTotal);
        }
        
        
    }
}
