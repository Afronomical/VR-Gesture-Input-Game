using System.Collections.Generic;
using UnityEngine;

public class DragWaterBall_Ability : Ability
{
    private WaterOrb_Control waterOrb;

    private Vector3 dragInDirection;
    [SerializeField]private float maxBallDist;
    WaterOrb_Control recentWaterOrb;

    [SerializeField] List<WaterOrb_Control> waterOrbs;

    [SerializeField] LayerMask ignoreLayer;


    protected override void Start()
    {
        GestureManager.OnGestureActive += MoveWaterBall;
        GestureManager.OnGestureStarted += SelectWaterBall;
        GestureManager.OnGestureExit += Reset;
    }
    private void Reset(GestureDataSO gesture)
    {
        if (gesture == requiredGestures[0])
        {
            if(waterOrb != null)
            {
                waterOrb.Release();
            }
            

        }
    }
    void MoveWaterBall(GestureDataSO gesture)
    {
        if(gesture == requiredGestures[0])
        {
            if(waterOrb != recentWaterOrb)
            {

            }
            if(waterOrb != null)
            {
                RaycastHit hit;
                if (Physics.Raycast(playerHead.transform.position, playerHead.transform.forward, out hit, maxBallDist, ~ignoreLayer))
                {
                    waterOrb.HoverToPosition(hit.point);
                }
                else
                {
                    waterOrb.HoverToPosition(playerHead.transform.position + playerHead.transform.forward * maxBallDist);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.TryGetComponent(out waterOrb))
        {
            waterOrbs.Add(waterOrb);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out waterOrb))
        {
            waterOrbs.Remove(waterOrb);
            waterOrb = null;
        }


    }


    void SelectWaterBall(GestureDataSO gesture)
    {
        if (gesture == requiredGestures[0])
        {
            Vector3 measuringPoint;
            RaycastHit hit;
            if (Physics.Raycast(playerHead.transform.position, playerHead.transform.forward, out hit, maxBallDist ))
            {
                measuringPoint = new Vector3(hit.point.x, playerHead.transform.position.y, hit.point.z);
            }
            else
            {
                Vector3 removeY = Vector3.forward + Vector3.right;
                measuringPoint = playerHead.transform.position
                               + new Vector3(playerHead.transform.forward.x,
                                                playerHead.transform.position.y,
                                                playerHead.transform.forward.z)
                               * maxBallDist;
            }
            float lastClosestDistance = float.MaxValue;
            WaterOrb_Control closestWaterOrb = null;
            foreach (WaterOrb_Control item in waterOrbs)
            {
                if (closestWaterOrb == null)
                {
                    closestWaterOrb = item;
                }
                if (closestWaterOrb == null)
                {
                    //Debug.LogWarning("Closest WaterOrb is null");
                    return;
                }
                if (!item.gameObject.activeSelf)
                {
                    //item.Push(pushDirection.forward, pushForce);
                    //Debug.Log("Push called");
                    waterOrbs.Remove(waterOrb);
                    continue;
                }


                float distance = Vector3.Distance(measuringPoint, item.transform.position);
                if (distance < lastClosestDistance)
                {
                    lastClosestDistance = distance;
                    closestWaterOrb = item;
                }

               
            }
        }

    }
}
