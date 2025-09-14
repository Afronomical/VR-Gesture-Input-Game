using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public enum WaterState
{
    Default,
    Thrown,
    Caught
}
public class WaterOrb_Control : MonoBehaviour
{

    public ParticleSystem particleSystem;

    [SerializeField] GameObject _SplashPrefab;
    [SerializeField] GameObject _SpillPrefab;
    public Rigidbody rb;
    public GameObject waterBall;
    [SerializeField] float moveSpeed;
    Vector3 releasedPosition;

    Vector3 previousFramePos;

    public float MaxScale = 4.0f;

    public void HoverToPosition(Vector3 target)
    {
        rb.useGravity = false;
        transform.position = Vector3.Lerp(transform.position, target, moveSpeed);
    }
    public void Release()
    {
        rb.useGravity = true;
    }
    public void FloorSplash( Vector3 _spawnPos, Vector3 _spawnRot)
    {
        Vector3 startPos = releasedPosition;
        Quaternion normalRotation = Quaternion.FromToRotation(transform.up, _spawnRot);

        Vector3 movementDirection = previousFramePos - transform.position;

        Debug.Log(normalRotation.eulerAngles);
        //_WaterBallParticleSystem.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
        GameObject splas = Instantiate(_SplashPrefab, new Vector3(_spawnPos.x, _spawnPos.y, _spawnPos.z), normalRotation);
        
       /* Vector3 forward = transform.position - startPos;
        forward.y = 0;
        splas.transform.forward = forward;*/


        if (Vector3.Angle(startPos - transform.position, Vector3.up) > 30)
        {
            GameObject spill = Instantiate(_SpillPrefab, _spawnPos, normalRotation);
            //spill.transform.forward = forward;
        }

        Vector3.Angle(_spawnPos, transform.position);

        Destroy(gameObject);
    }
    
    public void GrowBallByFactor(float multiplier)
    {

    }
    public void GrowBallByCombinedScale(float combinedScale)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        FloorSplash(collision.GetContact(0).point, collision.GetContact(0).normal);
        
        
    }

    private void LateUpdate()
    {
        previousFramePos = transform.position;
    }
}

