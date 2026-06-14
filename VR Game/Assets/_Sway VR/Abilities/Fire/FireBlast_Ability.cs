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
    private void Update()
    {
        Debug.DrawLine(rightHand.transform.position + rightHand.transform.rotation * offsetFromHand, rightHand.transform.position + rightHand.transform.rotation * offsetFromHand * 5); 
        Gizmos.DrawCube(rightHand.transform.position + rightHand.transform.rotation * offsetFromHand, new Vector3(1, 1, 1));
    }
    void SpawnFireBall()
    {
        Instantiate(projectile, rightHand.transform.position + rightHand.transform.rotation * offsetFromHand , playerHead.transform.rotation);
    }
}
