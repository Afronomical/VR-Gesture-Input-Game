using UnityEngine;
using System.Collections.Generic;


public enum E_StatusIndex
{
    burn,
    wet,
    frozen,
    
}
public class StatusEffectData
{
    [SerializeField] E_StatusIndex statusType;
    [SerializeField]int stacks = 1;
    public E_StatusIndex GetStatusType()
    {
        return statusType;
    }
    public int GetStacks()
    {
        return stacks;
    }

    [SerializeField] List<int> StatusEffectStacks;

    //Setup the data using a scriptable object. Allowing it to be instantiated
    public void SetupData(StatusDataSO dataSo)
    {
        statusType = dataSo.GetStatus();
        stacks = dataSo.GetStacks();
    }
}
