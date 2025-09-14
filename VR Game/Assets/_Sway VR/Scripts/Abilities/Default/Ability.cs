using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public abstract class Ability : MonoBehaviour
{

    [SerializeField]protected GameObject playerHead;
    public string abilityName = "DefaultAbilityName";
    [Tooltip("The time the player must complete the gestures, in order to activate the ability")]
    public float activationTimer = 1f;

    [Tooltip("The time the player must wait to activate the ability since the previous activation")]
    public float cooldownTimer = 0.5f;
    protected bool isCooldownComplete = true;

    public float ongoingTimer = 1f;

    protected event Action OnActivateAbility;

    bool _isActive = false;
    protected bool isActive
    {
        get { return _isActive; } 
        set { _isActive = value;  gestureIndex = 0; }
    }

    [SerializeField]protected int gestureIndex = 0;

    public int GetGestureIndex()
    {
        return gestureIndex;
    }
    [Tooltip("The sequence of gestures the player must complete to activate an ability")]
    [SerializeField]public GestureDataSO[] requiredGestures;

    public AbilityManager abilityManager;

    protected virtual void Start()
    {
        playerHead = abilityManager.player;
    }
    protected virtual void OnEnable()
    {
        playerHead = abilityManager.player;
    }
    public void Initialize(AbilityManager _abilityManager)
    {
        abilityManager = _abilityManager;
    }
    public void SetActive(bool _isActive)
    {
        isActive= _isActive;

        gestureIndex = 0;
    }

    /*void CheckGesture(GestureDataSO gesture)
    {
        if (!isCooldownComplete) return;

        if (gesture == requiredGestures[gestureIndex])
        {

            gestureIndex++;

            if (gestureIndex >= requiredGestures.Length)
            {
                //Complete Ability

                ActivateAbility();
            }

        }
        else if (gestureIndex != 0 && gesture == requiredGestures[0])
        {
            gestureIndex = 0;
        }
        else
        {

        }

    }*/

    protected void ActivateAbility()
    {
        OnActivateAbility?.Invoke();
        StartCooldown();
    }
    protected void StartCooldown()
    {
        StartCoroutine(BeginCooldown());
    }

    IEnumerator BeginCooldown()
    {
        if (isCooldownComplete)
        {
            isCooldownComplete = false;

            yield return new WaitForSeconds(cooldownTimer);

            gestureIndex = 0;
            isCooldownComplete = true;
        }
        
    }
    
    IEnumerator StartActivationTimer()
    {
        yield return new WaitForSeconds(activationTimer);

        if(gestureIndex > 0 && isCooldownComplete == true)
        {
            gestureIndex= 0;
            StopAllCoroutines();
        }
    }
    IEnumerator StartActiveTimer()
    {
        yield return new WaitForSeconds(ongoingTimer);
    }
}
