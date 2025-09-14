using UnityEngine;

public class VRFirstPersonCam : MonoBehaviour
{
    [Tooltip("The type of rotation applied when the stick is moved")]
    public enum LookType
    {
        Continuous,
        Snap
    }


    [SerializeField]LookType lookType;


    
}
