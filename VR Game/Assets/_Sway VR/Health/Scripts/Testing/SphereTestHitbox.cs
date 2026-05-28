using System.Linq;
using UnityEngine;

public class SphereTestHitbox : MonoBehaviour
{

    public GameObject hitParticle;
    public GameObject damagePopUp;
    public Vector3 dmgPopUpOffset;
    public int damageTotal = 5;
    public StatusDataSO effectDataSO;
    public StatusEffectData effectData = new StatusEffectData();
    public Color dmgColour = Color.white;

    private void Start()
    {
        
        effectData.SetupData(effectDataSO);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject GO = collision.gameObject;
        if (GO.GetComponent<IDamageable>() != null)
        {
            if (GO.GetComponent<IDamageable>().DamageHP(damageTotal))
            {
                GameObject popUp = Instantiate(damagePopUp, collision.contacts[0].point + dmgPopUpOffset, Quaternion.identity);
                popUp.GetComponent<DamagePopUpTextUpdater>().UpdateDamageText(damageTotal);
                popUp.GetComponent<DamagePopUpTextUpdater>().UpdateColour(dmgColour);
            }
            

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
