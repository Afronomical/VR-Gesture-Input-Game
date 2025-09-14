using UnityEngine;

public class Movement_Walking : MonoBehaviour
{
    public float walkSpeed = 10f;
    private float currentWalkSpeed;

    Vector3 moveDirection;
    public Vector3 appliedForce;

    float horizontalInput;
    float verticalInput;

    Vector2 inputVector;

    Transform orientation;

    XRIDefaultInputActions input;

    [SerializeField]PlayerMovementHandler moveHandler;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = moveHandler.rb;
        input = new XRIDefaultInputActions();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    public void Initialize(PlayerMovementHandler movementHandler)
    {
        moveHandler = movementHandler;
        
    }

    // Update is called once per frame
    void Update()
    {

        HandleInput();
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        MovePlayer();
    }

    void HandleInput()
    {
        inputVector = input.XRILeftLocomotion.Move.ReadValue<Vector2>();
    }
    private void MovePlayer()
    {
        if (moveHandler.isGrounded)
        {
            appliedForce = moveDirection * walkSpeed;
        }
    }
}
