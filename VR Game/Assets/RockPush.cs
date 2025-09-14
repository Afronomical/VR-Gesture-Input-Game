using UnityEngine;
using System.Collections.Generic;

public class RockPush : Ability
{

    //private SphereCollider collider;

    [SerializeField]float pushForce = 10;
    [SerializeField]Transform pushDirection;
    
    [SerializeField]List<PushableRock> pushableObjects;
    PushableRock currentRock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //collider = GetComponent<SphereCollider>();
        GestureManager.OnGestureStarted += PushObject;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if(other.TryGetComponent(out currentRock))
        {
            pushableObjects.Remove(currentRock);
            currentRock = null;
        }
        
        
    }

    public void PushObject(GestureDataSO gesture)
    {

        if(gesture == requiredGestures[requiredGestures.Length])
        {
            foreach (PushableRock item in pushableObjects)
            {
                if(item.gameObject.activeSelf)
                {
                    item.Push(pushDirection.forward, pushForce);
                    Debug.Log("Push called");
                }
                else
                {
                    pushableObjects.Remove(item);
                }
            }
        }
        
    }
}
