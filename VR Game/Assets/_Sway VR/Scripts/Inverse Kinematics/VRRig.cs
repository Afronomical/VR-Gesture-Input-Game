using UnityEngine;
using Unity.Mathematics;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public float lerpSpeed = 1.0f;
    public void Map()
    {
        rigTarget.position =  Vector3.Lerp(rigTarget.position, vrTarget.TransformPoint(trackingPositionOffset), lerpSpeed);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}
public class VRRig : MonoBehaviour
{
    
    public Transform headConstraint;
    private Vector3 headBodyOffset;

    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

   
    private void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    private void LateUpdate()
    {
        //transform.position = headConstraint.position + headBodyOffset;

        transform.position = Vector3.Lerp(transform.position, headConstraint.position + headBodyOffset, 1000f);

        transform.forward = Vector3.ProjectOnPlane(headConstraint.forward, Vector3.up).normalized;

        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
