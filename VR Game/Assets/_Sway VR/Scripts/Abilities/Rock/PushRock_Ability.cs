using System.Collections.Generic;
using UnityEngine;

public class PushRock_Ability : Ability
{

    [SerializeField] float pushForce = 10f;
    [SerializeField] float rockSelectionRange = 1f;
    [SerializeField] Transform pushDirection;

    [SerializeField] List<PushableRock> pushableObjects;
    PushableRock currentRock;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        GestureManager.OnGestureStarted += PushObject;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        SphereCollider sphereColl;
        TryGetComponent<SphereCollider>(out sphereColl);
        rockSelectionRange = sphereColl.radius;
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.TryGetComponent(out currentRock))
        {
            pushableObjects.Add(currentRock);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out currentRock))
        {
            pushableObjects.Remove(currentRock);
            currentRock = null;
        }


    }

    public void PushObject(GestureDataSO gesture)
    {
        
        if (gesture == requiredGestures[0])
        {
            PushableRock closestRock = null;
           
            float lastClosestDistance = float.MaxValue;

            Vector3 measuringPoint;
            RaycastHit hit;
            if (Physics.Raycast(playerHead.transform.position, pushDirection.forward, out hit, rockSelectionRange))
            {
                measuringPoint = new Vector3(hit.point.x, playerHead.transform.position.y, hit.point.z);
            }
            else
            {
                Vector3 removeY = Vector3.forward + Vector3.right;
                measuringPoint  = playerHead.transform.position 
                               + new Vector3(   pushDirection.forward.x, 
                                                playerHead.transform.position.y, 
                                                pushDirection.forward.z)
                               * rockSelectionRange;
            }
            foreach (PushableRock item in pushableObjects)
            {
                if (closestRock == null)
                {
                    closestRock = item;
                }
                if (closestRock == null)
                {
                    Debug.LogWarning("Closest Rock is null");
                    return;
                }
                if (!item.gameObject.activeSelf)
                {
                    item.Push(pushDirection.forward, pushForce);
                    Debug.Log("Push called");
                    pushableObjects.Remove(item);
                    continue;
                }


                float distance = Vector3.Distance(measuringPoint, item.transform.position);
                if (distance < lastClosestDistance)
                {
                    lastClosestDistance = distance;
                    closestRock = item;
                }

                
            }
            if(closestRock == null)
            {
                return;
            }
            closestRock.Push(pushDirection.forward, pushForce);
            Debug.Log("Push called");
        }

    }
}

