using UnityEngine;

public class GestureDebugHelper : MonoBehaviour
{

    
    //Visuals for each hands Transforms
    [SerializeField]MeshRenderer allCorrectSphere,leftPositionSphere, rightPositionSphere, leftRotationSphere, rightRotationSphere;

    public GestureReader manager;

    //Colour to set the respective visual to
    [SerializeField]Material trueMat, falseMat;

    //What gesture is this visual representing
    public GestureDataSO currentGestureData;

    //A visual representation of the target gesture (Pseudo tutorial)
    public GameObject gestureDisplayL, gestureDisplayR;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //manager = GetComponent<GestureManager>();
    }

    // Update is called once per frame
    void Update()
    {

        currentGestureData = manager.debuggingGesture;
        CheckRight();
        CheckLeft();
        if(manager.CheckGesture(currentGestureData))
        {
            allCorrectSphere.material = trueMat;
        }
        else
        {
            allCorrectSphere.material = falseMat;
        }
        if(gestureDisplayL != null && gestureDisplayR != null)
        {
            gestureDisplayR.transform.position = manager.AdjustPositionToPlayer(currentGestureData.rPosition);
            gestureDisplayL.transform.position = manager.AdjustPositionToPlayer(currentGestureData.lPosition);

            gestureDisplayR.transform.rotation = manager.AdjustRotationToPlayer(currentGestureData.rRotation);
            gestureDisplayL.transform.rotation = manager.AdjustRotationToPlayer(currentGestureData.lRotation);
        }
        
    }

    private void CheckLeft()
    {
        if (manager.isLeftPosTrue)
        {
            leftPositionSphere.material = trueMat;
        }
        else if (!manager.isLeftPosTrue)
        {
            leftPositionSphere.material = falseMat;
        }
        if (manager.isLeftRotTrue)
        {
            leftRotationSphere.material = trueMat;
        }
        else if (!manager.isLeftRotTrue)
        {
            leftRotationSphere.material = falseMat;
        }
    }

    private void CheckRight()
    {
        if (manager.isRightPosTrue)
        {
            rightPositionSphere.material = trueMat;
        }
        else if (!manager.isRightPosTrue)
        {
            rightPositionSphere.material = falseMat;
        }
        if (manager.isRightRotTrue)
        {

            rightRotationSphere.material = trueMat;
        }
        else if (!manager.isRightRotTrue)
        {

            rightRotationSphere.material = falseMat;
        }
    }
}
