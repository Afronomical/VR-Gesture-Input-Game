using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{


    /* My Object Pooling system needs to create a pool at the start; retrieve, return, instantiate and destroy
      objects in the pool, and call an Event for each.

    If pool is empty, create a new instance
    If pool is filled get an instance from the pool
    If pool is full destroy any lingering instances

    When retrieved from the pool, object is setActive(true)
    When returned to the pool, object is setActive(false)

    Each object should have an IPoolable interface
     
     */

    GameObject prefab;
    private Queue<GameObject> pool;
    [Tooltip("The max number of items in the pool. Any returned above this number are destroyed")]
    public float poolMax = 100;
    [Tooltip("The number of items the pool starts with. More are added if the pool is full")]
    public float initialNum = 10;
    public GameObject GetObject()
    {
        if(pool.Count > 0 )
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        return Instantiate(prefab);
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
