using UnityEngine;
using System.Collections;

enum E_RockState
{
    Static = 0,
    Pushed = 1,
    collide = 2,
}
[RequireComponent (typeof(Rigidbody))]
public class PushableRock : MonoBehaviour
{
    [SerializeField] private float moveForSeconds = 1f;
    Vector3 moveDirection;

    [Tooltip("A multiplier used effect the force applied on a rock depending on it's type. \n This allows for heavier rocks to seem heavier")]
    [SerializeField]private float forceMultiplier = 1;
    private float activeForce;

    Rigidbody rb;

    [SerializeField]E_RockState moveState = E_RockState.Static;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        switch (moveState)
        {
            case E_RockState.Static:
                break;
            case E_RockState.Pushed:
                
                break;
            case E_RockState.collide:
                break;
            default:
                break;
        }
    }

    public void Push(Vector3 directionToLaunch, float appliedForce)
    {
        moveDirection= directionToLaunch;
        activeForce = appliedForce;
        StopCoroutine(PushingRock());
        StartCoroutine(PushingRock());
        Debug.Log("launched rock");
    }
    
    IEnumerator PushingRock()
    {
        rb.linearVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        moveState = E_RockState.Pushed;
        rb.AddForce(moveDirection * activeForce * forceMultiplier, ForceMode.VelocityChange);
        yield return new WaitForSeconds(moveForSeconds);

        //rb.linearVelocity = Vector3.zero;
        moveState = E_RockState.Static;
        rb.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(moveForSeconds);

        
    }
}
