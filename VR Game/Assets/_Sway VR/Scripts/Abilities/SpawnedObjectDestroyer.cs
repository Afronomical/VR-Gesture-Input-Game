using UnityEngine;

public class SpawnedObjectDestroyer : MonoBehaviour
{

    [SerializeField] float lifetime = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("DestroyMe", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyMe()
    {
        if(gameObject != null)
        {
            Destroy(gameObject);
        }
        
    }
}
