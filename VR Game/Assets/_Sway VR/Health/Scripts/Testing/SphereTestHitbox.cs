using System.Linq;
using UnityEngine;

public class SphereTestHitbox : MonoBehaviour
{

    public GameObject hitParticle;
    public int damageTotal = 5;
    public StatusDataSO effectDataSO;
    public StatusEffectData effectData = new StatusEffectData();

    private void Start()
    {
        
        effectData.SetupData(effectDataSO);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject GO = collision.gameObject;
        if (GO.GetComponent<IDamageable>() != null)
        {
            GO.GetComponent<IDamageable>().DamageHP(damageTotal);
        }
        if(GO.GetComponent<IStatusEffectable>() != null)
        {
            GO.GetComponent<IStatusEffectable>().ApplyEffect(effectData);
        }


        Instantiate(hitParticle, collision.contacts[0].point, Quaternion.FromToRotation(gameObject.transform.position, collision.gameObject.transform.position) );

        
        
    }

    private void Update()
    {
       
    }
}
