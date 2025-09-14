using UnityEngine;
using UnityEngine.InputSystem;

public class GestureUpdater : MonoBehaviour
{
    [SerializeField]GestureDataSO gestureToUpdate;
    [SerializeField] GestureReader gestureReader;

    XRIDefaultInputActions input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gestureReader= GetComponent<GestureReader>();   
    }
    private void Awake()
    {
        input= new XRIDefaultInputActions();
    }
    private void OnEnable()
    {
        input.XRILeftInteraction.Enable();

        input.XRILeftInteraction.Activate.performed += SetNewPose;
    }
    private void OnDisable()
    {
        input.XRILeftInteraction.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        gestureToUpdate = gestureReader.debuggingGesture;
    }

    void SetNewPose(InputAction.CallbackContext ctx)
    {
        //Update the scriptable object for a gesture
        gestureToUpdate.rPosition = gestureReader.GetRightTransform().position;
        gestureToUpdate.rRotation = gestureReader.GetRightTransform().rotation;

        gestureToUpdate.lPosition = gestureReader.GetLeftTransform().position;
        gestureToUpdate.lRotation = gestureReader.GetLeftTransform().rotation;

        Debug.Log(gestureToUpdate.name + " has been updated to reflect player's current pose");
    }
}