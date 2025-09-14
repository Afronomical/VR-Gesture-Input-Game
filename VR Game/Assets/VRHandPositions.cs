using UnityEngine;


public class VRHandPositions : MonoBehaviour
{
    public Animator rightHandAnimator;
    public Animator leftHandAnimator;

    XRIDefaultInputActions controller;

    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";


    float leftGrip, rightGrip;
    float leftTrigger, rightTrigger;

    private void Awake()
    {
        controller = new XRIDefaultInputActions();
    }
    private void OnEnable()
    {
        controller.Enable();
    }

    private void Update()
    {
        SetGrip(false, controller.XRILeftInteraction.SelectValue.ReadValue<float>());
        SetGrip(true, controller.XRIRightInteraction.SelectValue.ReadValue<float>());


        SetTrigger(false, controller.XRILeftInteraction.ActivateValue.ReadValue<float>());
        SetTrigger(true, controller.XRIRightInteraction.ActivateValue.ReadValue<float>());

        AnimateHand();
    }

    private void AnimateHand()
    {
        leftHandAnimator.SetFloat(animatorGripParam, leftGrip);
        leftHandAnimator.SetFloat(animatorTriggerParam, leftTrigger);

        rightHandAnimator.SetFloat(animatorGripParam, rightGrip);
        rightHandAnimator.SetFloat(animatorTriggerParam, rightTrigger);

    }
    void SetGrip(bool isRightHand, float gripValue )
    {
        if(isRightHand)
        { 
            rightGrip = gripValue;
            
        }
        else
        {
            leftGrip = gripValue;
        }
    }
    void SetTrigger(bool isRightHand, float triggerValue)
    {
        if(isRightHand)
        {
            rightTrigger = triggerValue;
        }
        else
        {
            leftTrigger = triggerValue;
        }
    }



}
