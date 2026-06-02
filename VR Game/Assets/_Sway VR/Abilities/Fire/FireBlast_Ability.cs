using UnityEngine;

public class FireBlast_Ability : Ability
{

    ObjectPool projectilePool;
    [SerializeField]GameObject projectile;

    public Vector3 offsetFromHand;

    protected override void Start()
    {
        base.Start();
        GestureManager.OnGestureStarted += CheckGesture;
        abilityManager.AddAbility(this);
    }

    void CheckGesture(GestureDataSO gesture)
    {
        if (!isCooldownComplete) return;

        if (gesture == requiredGestures[gestureIndex] )
        {
                
            if(gestureIndex >= requiredGestures.Length - 1)
            {
                gestureIndex = 0;
                SpawnFireBall();

            }
            else
            {
                gestureIndex++;
            }
            

        }
        else if (gestureIndex > requiredGestures.Length -1 )
        {
            
            gestureIndex = 0;
        }
        
    }

    void SpawnFireBall()
    {
        Instantiate(projectile, rightHand.transform.position + offsetFromHand, playerHead.transform.rotation);
    }
}
