using System;
using System.Linq;
using UnityEngine;

public class SphereTestHitbox : MonoBehaviour
{

    public GameObject hitParticle;
    public GameObject damagePopUp;
    public Vector3 dmgPopUpOffset;
    public DamageDataSO damageData;

    public Color dmgColour = Color.white;

    public event Action<int> OnDamage;
    private void Start()
    {
        
        //effectData.SetupData(effectDataSO);
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject GO = collision.gameObject;
        if (GO.GetComponent<IDamageable>() != null)
        {
            if (GO.GetComponent<IDamageable>().Damage(damageData))
            {
                GameObject popUp = Instantiate(damagePopUp, collision.contacts[0].point + dmgPopUpOffset, Quaternion.identity);
                popUp.GetComponent<DamagePopUpTextUpdater>().UpdateDamageText(damageData.damageVal);
                popUp.GetComponent<DamagePopUpTextUpdater>().UpdateColour(dmgColour);
                //OnDamage(damageTotal);
            }
            

        }
        /*if(GO.GetComponent<IStatusEffectable>() != null)
        {
            GO.GetComponent<IStatusEffectable>().ApplyEffect(effectData);
        }*/


        Instantiate(hitParticle, collision.contacts[0].point, Quaternion.FromToRotation(gameObject.transform.position, collision.gameObject.transform.position) );
        
        
    }

    private void Update()
    {
       
    }
}
