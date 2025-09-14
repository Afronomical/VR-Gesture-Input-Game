using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using System.Collections;

using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;
using System;

public class Run_Ability : Ability
{
    public DynamicMoveProvider moveProvider;
    float walkSpeed = 2;
    public float sprintSpeed = 5;
    public float runTimer = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GestureManager.OnGestureStarted += ChangeRunMode;
        walkSpeed = moveProvider.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        //moveProvider.moveSpeed = 10;
    }
    void SetMoveSpeed(float newSpeed)
    {

        moveProvider.moveSpeed = newSpeed;

    }
    void ChangeRunMode(GestureDataSO gesture)
    {
        if (gesture == requiredGestures[gestureIndex])
        {
            SetMoveSpeed(sprintSpeed);
            if (gestureIndex >= requiredGestures.Length)
            {
                gestureIndex = 0;
                

            }
        }
        else
        {
            StopCoroutine(StopRunning());
            StartCoroutine(StopRunning());
        }

        
    }
    IEnumerator StopRunning()
    {
        yield return new WaitForSeconds(runTimer);
        SetMoveSpeed(walkSpeed);
    }
}
