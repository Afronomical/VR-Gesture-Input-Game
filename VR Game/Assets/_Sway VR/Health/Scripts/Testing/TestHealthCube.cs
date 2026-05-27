using System;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthCube : Health, IStatusEffectable
{
    [SerializeField] List<int> statusList;

    private void Start()
    {
        //Ensure the list has the amount of values in the Status Index. Syncing the two "Arrays"
        for(int i = statusList.Count; i < Enum.GetValues(typeof(E_StatusIndex)).Length; i++)
        {
            statusList.Add(0);
        }
    }
    public void ApplyEffect(StatusEffectData effectData)
    {
        int newEffectType = (int)effectData.GetStatusType();

        statusList[(int)effectData.GetStatusType()] += effectData.GetStacks();
        int numOfTypes = Enum.GetValues(typeof(E_StatusIndex)).Length;
        //Debug.Log(statusList[(int)effectData.GetStatusType()].ToString());
    }
    public void RemoveEffect(StatusEffectData effectData)
    {
        int newEffectType = (int)effectData.GetStatusType();

        //Ensure statuses being removed don't become negative
        if (statusList[newEffectType] >= effectData.GetStacks())
        {
            statusList[newEffectType] -= effectData.GetStacks();
        }
        else
        {
            statusList[newEffectType] = 0;
        }
    }
    public void ClearAllEffects()
    {
        statusList.Clear();
    }
    public void ClearEffect(StatusEffectData effectData)
    {
        statusList[(int)effectData.GetStatusType()] = 0;
    }
}
