using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementHandler : MonoBehaviour
{
    public Rigidbody rb;
    public Camera playerHead;
    public bool isGrounded;
    Vector3[] allAppliedForces;
    Vector3 totalAppliedForce;


    [SerializeField]Movement_Walking walkingScript;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        TryGetComponent(out rb);
    }

    private void Start()
    {
        rb.freezeRotation= true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        totalAppliedForce = Vector3.zero;
        /*foreach (var force in allAppliedForces)
        {
            totalAppliedForce += force;
        }*/

        totalAppliedForce = walkingScript.appliedForce;
        rb.AddForce(totalAppliedForce.normalized * 10f, ForceMode.Force);
    }

    
}