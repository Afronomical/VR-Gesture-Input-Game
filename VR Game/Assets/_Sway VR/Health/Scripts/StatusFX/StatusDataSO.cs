using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatusDataSO", menuName = "SwayVR/StatusDataSO")]

public class StatusDataSO : ScriptableObject
{
    [SerializeField] E_StatusIndex status;

    public E_StatusIndex GetStatus()
    {
        return status;
    }

    [SerializeField] int stacks = 1;

    public int GetStacks()
    {
        return stacks;
    }
    
}
