using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

[RequireComponent(typeof(GestureReader))]
public class GestureManager : MonoBehaviour
{
    public XRIDefaultInputActions inputActions;

    public GestureDataSO[] gestureLibrary;

    [SerializeField] int currentGestureIndex = 0;

    public static GestureManager instance;

    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance= this;
            
        }
    }
    //[SerializeField] Dictionary<GestureDataSO, InputState> gestureActiveStates  = new Dictionary<GestureDataSO, InputState>();
    //The gesture that is targeted for adjustment
    public GestureDataSO currentDebugGesture;

    public GestureReader gestureReader;
    //Event that all scripts that get GestureInput are subscribed to
    public static event Action<GestureDataSO> OnGestureStarted;
    public static event Action<GestureDataSO> OnGestureActive;
    public static event Action<GestureDataSO> OnGestureExit;

    private void OnEnable()
    {
        inputActions= new XRIDefaultInputActions();
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    private void Start()
    {

        //inputActions.XRIRightInteraction.Select.performed += ChangeTestGesture;

       /* OnGestureStarted += GestureStartedEventCalled;
        OnGestureActive += GestureContinuedEventCalled;
        OnGestureExit += GestureEndedEventCalled;*/


        gestureReader = GetComponent<GestureReader>();
        
       
    }
    
    private void Update()
    {
        //Update the gesture for debug visuals and the target for being updated
        gestureReader.debuggingGesture = currentDebugGesture;
        

        foreach (GestureDataSO pose in gestureLibrary)
        {
            gestureReader.UpdateGestureState(pose);


            if (GestureReader.GetGestureState(pose).inactive)
            {
                continue;
            }
            else if (GestureReader.GetGestureState(pose).started)
            {
                OnGestureStarted?.Invoke(pose);
            }
            else if (GestureReader.GetGestureState(pose).continued)
            {
                OnGestureActive?.Invoke(pose);
            }
            else if (GestureReader.GetGestureState(pose).ended)
            {
                OnGestureExit?.Invoke(pose);
            }
           
        }
    }


    void GestureStartedEventCalled(GestureDataSO gestureData)
    {
        Debug.Log("GestureStarted: " + gestureData.name);
    }
    void GestureContinuedEventCalled(GestureDataSO gestureData)
    {
        Debug.Log("GestureContinued: " + gestureData.name);
    }

    void GestureEndedEventCalled(GestureDataSO gestureData)
    {
        Debug.Log("GestureEnded: " + gestureData.name);
    }

    void ChangeTestGesture(InputAction.CallbackContext ctx)
    {
        currentGestureIndex++;
        if(currentGestureIndex > gestureLibrary.Length - 1)
        {
            currentGestureIndex = 0;
        }

        currentDebugGesture = gestureLibrary[currentGestureIndex];

    }
}
