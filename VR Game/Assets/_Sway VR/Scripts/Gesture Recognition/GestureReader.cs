using UnityEngine;
using UnityEngine.InputSystem;

public struct GestureActiveData
{


    bool activeThisFrame, activeLastFrame;


    public GestureActiveData(bool gestureActiveThisFrame, bool gestureActiveLastFrame)
    {
        activeThisFrame = gestureActiveThisFrame;
        activeLastFrame = gestureActiveLastFrame;
    }
    public bool started
    {
        get { return activeThisFrame && !activeLastFrame; }
    }
    public bool continued
    {
        get { return activeThisFrame && activeLastFrame; }
    }
    public bool ended
    {
        get { return !activeThisFrame && activeLastFrame; }
    }
    public bool inactive
    {
        get { return !activeThisFrame && !activeLastFrame; }
    }


}
public struct HandButtonState
{
    public bool thumb, index, grip;
}


public class GestureReader : MonoBehaviour
{

    [SerializeField] GameObject rightHand;
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject Head;

    public GestureDataSO debuggingGesture;

    XRIDefaultInputActions input;

    HandButtonState lHand;
    HandButtonState rHand;

    float gripPressRequirement = 0.3f;
    public Transform GetHeadTransform()
    {
        Transform transf = Head.transform;
        return transf;
    }
    public Transform GetRightTransform()
    {
        Transform transf = transform;
        transf.position = Head.transform.InverseTransformPoint(rightHand.transform.position);

        transf.rotation = Quaternion.Inverse(Head.transform.rotation) * rightHand.transform.rotation;
        return transf;
    }
    public Transform GetLeftTransform()
    {

        Transform transf = transform;
        transf.position = Head.transform.InverseTransformPoint(leftHand.transform.position);

        transf.rotation = Quaternion.Inverse(Head.transform.rotation) * leftHand.transform.rotation;
        return transf;
    }
    [HideInInspector] public bool isLeftPosTrue;
    [HideInInspector] public bool isLeftRotTrue;    
    [HideInInspector] public bool isRightPosTrue;
    [HideInInspector] public bool isRightRotTrue;

    private void Awake()
    {
        input = new XRIDefaultInputActions();
    }

    // Update is called once per frame
    void Update()
    {
        DebugGesture();
    }
    public void OnEnable()
    {
        input.XRILeftInteraction.Enable();     
        input.XRIRightInteraction.Enable();     
    }
    private void OnDisable()
    {
        input.XRILeftInteraction.Disable();
        input.XRIRightInteraction.Disable();
    }

    public void UpdateGestureState(GestureDataSO gesture)
    {
        gesture.activeLastFrame = gesture.activeThisFrame;

        gesture.activeThisFrame = CheckGesture(gesture);
    }

    public Vector3 AdjustPositionToPlayer(Vector3 offset)
    {
        //Adjusts offset based on players Y position.
        Quaternion yRotation = Quaternion.Euler(0, Head.transform.eulerAngles.y, 0);

       
        return Head.transform.position + yRotation * offset;
    }
    public Quaternion AdjustRotationToPlayer(Quaternion offset)
    {
        //Adjusts offset based on players rotation
        Quaternion yRotation = Quaternion.Euler(0, Head.transform.eulerAngles.y, 0);

        
        return yRotation * offset;
    }
    void UpdateHandButtons()
    {
        lHand.grip = input.XRILeftInteraction.ActivateValue.ReadValue<float>() > gripPressRequirement;
        lHand.index = input.XRILeftInteraction.SelectValue.ReadValue<float>() > gripPressRequirement;
        lHand.thumb = input.XRILeftInteraction.ThumbstickTouched.ReadValue<float>() > gripPressRequirement;

        rHand.grip = input.XRIRightInteraction.ActivateValue.ReadValue<float>() > gripPressRequirement;
        rHand.index = input.XRIRightInteraction.SelectValue.ReadValue<float>() > gripPressRequirement;
        rHand.thumb = input.XRIRightInteraction.ThumbstickTouched.ReadValue<float>() > gripPressRequirement;

    }
    public bool CheckGestureButtons(GestureDataSO gesture)
    {
        return lHand.grip == gesture.leftGrip && lHand.thumb == gesture.leftThumb && lHand.index == gesture.leftIndex &&
               rHand.grip == gesture.rightGrip && rHand.thumb == gesture.rightThumb && rHand.index == gesture.rightIndex;
    }
    public bool CheckGesturePosInRange(Vector3 currentPosition, Vector3 gesturePosition, float posThreshold)
    {
        //True if distance is less than threshold. Obvious I think...
        return Vector3.Distance(currentPosition, gesturePosition) < posThreshold;
    }
    public bool CheckGestureRotation(Quaternion currentRotation, Quaternion gestureRotation, float rotThreshold)
    {
        //True if the angle between them is less than threshold
        return (Quaternion.Angle(currentRotation, gestureRotation) < rotThreshold);
    }

    /// <summary>
    /// Returns the active data of the inputted gesture. Can then be further queried using gestureRef.started, gestureRef.continued or gestureRef.started
    /// </summary>
    /// <param name="gesture"></param>
    /// <returns></returns>
    public static GestureActiveData GetGestureState(GestureDataSO gesture)
    {
        return new GestureActiveData(gesture.activeThisFrame, gesture.activeLastFrame);
    }

    public bool CheckGesture(GestureDataSO gesture)
    {
        //Checks the position and rotation of each hand along with a mirrored version

        //TODO: Make mirrored position flipped on Head.Forward axis

        UpdateHandButtons();

        //Check original right hand
        if (!CheckGesturePosInRange(rightHand.transform.position, AdjustPositionToPlayer(gesture.rPosition), gesture.rPositionThreshold) ||
            !CheckGestureRotation(rightHand.transform.rotation, AdjustRotationToPlayer(gesture.rRotation), gesture.rRotationThreshold))
        {
            //If the original right hand fails, check for a mirrored version
            if (!CheckGesturePosInRange(leftHand.transform.position, AdjustPositionToPlayer(gesture.rPosition), gesture.rPositionThreshold) ||
                !CheckGestureRotation(leftHand.transform.rotation, AdjustRotationToPlayer(gesture.rRotation), gesture.rRotationThreshold))
            {
                return false; //Exit if both original and mirrored right hand fail
            }
        }
        //Check original left hand
        if (!CheckGesturePosInRange(leftHand.transform.position, AdjustPositionToPlayer(gesture.lPosition), gesture.lPositionThreshold) ||
            !CheckGestureRotation(leftHand.transform.rotation, AdjustRotationToPlayer(gesture.lRotation), gesture.rRotationThreshold))
        {
            //If the original left hand fails, check for mirrored version
            if (!CheckGesturePosInRange(rightHand.transform.position, AdjustPositionToPlayer(gesture.lPosition), gesture.lPositionThreshold) ||
                !CheckGestureRotation(rightHand.transform.rotation, AdjustRotationToPlayer(gesture.lRotation), gesture.rRotationThreshold))
            {
                return false; 
            }
        }
        //Button checks are disabled until I can make it so it can't be used for spam
       /* if(!CheckGestureButtons(gesture))
        {
            return false;
        }*/
        return true; // Gesture is valid if all checks pass

    }
    private void DebugGesture()
    {
     //Debug to chekc if   
        if (CheckGesturePosInRange(rightHand.transform.position, AdjustPositionToPlayer(debuggingGesture.rPosition), debuggingGesture.rPositionThreshold))
        {

            isRightPosTrue = true;
        }
        else
        {
            isRightPosTrue = false;
        }
        if (CheckGestureRotation(rightHand.transform.rotation, AdjustRotationToPlayer(debuggingGesture.rRotation), debuggingGesture.rRotationThreshold))
        {
            isRightRotTrue = true;
        }
        else
        {
            isRightRotTrue = false;
        }

        if (CheckGesturePosInRange(leftHand.transform.position, AdjustPositionToPlayer(debuggingGesture.lPosition), debuggingGesture.lPositionThreshold))
        {

            isLeftPosTrue = true;
        }
        else
        {
            isLeftPosTrue = false;
        }
        if (CheckGestureRotation(leftHand.transform.rotation, AdjustRotationToPlayer(debuggingGesture.lRotation), debuggingGesture.rRotationThreshold))
        {

            isLeftRotTrue = true;
        }
        else
        {
            isLeftRotTrue = false;
        }
    }
}
