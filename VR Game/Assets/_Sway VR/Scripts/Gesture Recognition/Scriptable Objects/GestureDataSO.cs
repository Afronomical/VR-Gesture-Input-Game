using UnityEngine;

[CreateAssetMenu(fileName = "GestureDataSO", menuName = "Gesture/GestureDataSO")]
public class GestureDataSO : ScriptableObject
{
    public string GestureName;

    [HideInInspector] public bool activeThisFrame;
    [HideInInspector] public bool activeLastFrame;


    [Header("Left Hand")]
    public Vector3 lPosition;
    public Quaternion lRotation;

    public float lPositionThreshold = 0.3f;
    public float lRotationThreshold = 30.0f;

    /*[Tooltip("Value = Button state \n 0 is untouched, 1 is resting on and 2 is pressed")]
    [Range(0, 1)]*/
    public bool leftThumb, leftIndex, leftGrip;



    [Header("Right Hand")]
    public Vector3 rPosition;
    public Quaternion rRotation;

    public float rPositionThreshold = 0.3f;
    public float rRotationThreshold = 30.0f;

    /*[Tooltip("Value = Button state \n 0 is untouched, 1 is resting on and 2 is pressed")]
    [Range(0, 1)]*/
    public bool rightThumb, rightIndex, rightGrip;
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
}

public enum EFingerState
{
    AwayFromButton,
    RestingOnButton,
    PressedButton,
}
