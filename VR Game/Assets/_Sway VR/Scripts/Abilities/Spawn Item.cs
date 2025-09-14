using UnityEngine;
using System.Collections;

public class SpawnItem : MonoBehaviour
{
    [SerializeField]GestureManager manager;

    [SerializeField]GestureDataSO gestureToActivate;

    [SerializeField]GameObject objectToSpawn;

    public float growRate = 1.0002f;
    GameObject createdObject;

    public float cooldown = 0.5f;

    Vector3 offset = new Vector3(0, 0, 5);
    Quaternion offsetRot = new Quaternion(0,0,0,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GestureManager.OnGestureStarted += Spawn;
        GestureManager.OnGestureExit += DeSpawn;
        GestureManager.OnGestureActive += WhilstSpawned;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Spawn(GestureDataSO gestureData )
    {
        if(gestureData == gestureToActivate && !createdObject)
        {
            GestureReader gestureRead = manager.gestureReader;
            
            createdObject = Instantiate(objectToSpawn, gestureRead.AdjustPositionToPlayer(offset), gestureRead.AdjustRotationToPlayer(offsetRot));
        }
    }
    void WhilstSpawned(GestureDataSO gestureData)
    {
        if (gestureData == gestureToActivate && createdObject)
        {
            createdObject.transform.localScale *= growRate * growRate;
        }
    }
    void DeSpawn(GestureDataSO gestureData)
    {
        if(gestureData == gestureToActivate && createdObject)
        {
            Destroy(createdObject);
            createdObject = null;
        }
    }    
}
