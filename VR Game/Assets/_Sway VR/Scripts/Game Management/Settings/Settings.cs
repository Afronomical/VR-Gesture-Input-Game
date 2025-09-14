using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class Settings : MonoBehaviour
{


    [Header("Rotation Settings")]

    public ControllerInputActionManager contInputManager;
    [SerializeField] SnapTurnProvider snapTurnScript;
    //[SerializeField] bool isSnapRotation;

    [SerializeField] int snapByDegrees;
    int minSnap, maxSnap;

    public bool isSnapRotating;

    XRIDefaultInputActions inputActions;
      [Space]

      

    [SerializeField] ContinuousTurnProvider continuousTurnScript;
    [SerializeField] public int turnSensitivity
    {
        get { return turnSensitivity; }

        set { turnSensitivity = Mathf.Clamp(value, minSnap, maxSnap); }
    }
    private void OnEnable()
    {
       inputActions= new XRIDefaultInputActions();
       inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
    private void Update()
    {
       
            
        
    }
    
    private void UpdateSnapRotate()
    {
        if (isSnapRotating)
        {
            /*snapTurnScript.enabled = true;
            continuousTurnScript.enabled = false;*/
            //OnSnapActive.Invoke();
            contInputManager.smoothTurnEnabled = true;
        }
        else
        {
            /* continuousTurnScript.enabled = true;
             snapTurnScript.enabled = true;*/
            // OnSnapInactive.Invoke();

            contInputManager.smoothTurnEnabled = false;
        }
    }

    public void SaveSettings()
    {
        SaveSystem.SaveSettings(this);
    }

    public void LoadSettings()
    {
        SettingsData data = SaveSystem.LoadSettings();

        //level = data.level
        //vice versa

        isSnapRotating= data.isSnapRotating;
    }
}
