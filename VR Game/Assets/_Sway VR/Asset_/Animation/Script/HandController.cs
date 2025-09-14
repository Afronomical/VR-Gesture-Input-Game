using UnityEngine;

public class HandController : MonoBehaviour
{

    XRIDefaultInputActions controller;

    public Hand hand;
    
    private void Awake()
    {
        controller= new XRIDefaultInputActions();

    }
    private void OnEnable()
    {
        controller.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        hand.SetGrip(controller.XRIRightInteraction.SelectValue.ReadValue<float>());
        hand.SetTrigger(controller.XRIRightInteraction.ActivateValue.ReadValue<float>());
    }
}
