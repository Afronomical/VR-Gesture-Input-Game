using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public enum DebugTag
{
    Head,
    LeftHand,
    RightHand,
    Settings
}
public class DebugHandler : MonoBehaviour
{
    public static DebugHandler instance;

    public DebugHandler GetInstance()
    {
        return this;
    }


    private DebugHandler()
    {
        
    }

   


    [SerializeField]
    DebugTag currentDebug;
    public void DebugConsole(string msg, DebugTag dbgTag)
    {
        if (dbgTag == currentDebug)
        {
            Debug.Log(msg);
        }
        
    }



    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}
