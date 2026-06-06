using UnityEngine;

public enum EStatusEffectType { burn, wet, frozen, shock }

[CreateAssetMenu(fileName = "StatusFXDataSO", menuName = "SwayVR/StatusEffects/StatusFXDataSO")]

public class StatusEffectSO : ScriptableObject
{
    [SerializeField, Header("Status  Type"), Tooltip("Integer key for what status type this is. \n New entries can be added to the EStatusEffectType enum")]
    private EStatusEffectType status;
    public EStatusEffectType Status {  get { return status; } }

    [SerializeField, Space ,Header("UI Elements")]
    [Tooltip("The colour shown on: damagePopUps, IconBackgrounds and anywhere this element is represented")]
    private Color color;
    public Color Color {  get { return color; } }

    [SerializeField, Tooltip("The Icon used to represent this element")]
    private Sprite icon;
    public Sprite Icon { get { return icon; } }

    /*[Space, Header("Configuration Data")]
    [Tooltip("Stacks of status needed to be met for ability to activate")]
    public float activationThreshold;
    [ Tooltip("¯|_(ツ)_|¯")]
    public float thresholdReductionMultiplier = 1f;
    [Tooltip("How many stacks of status are lost per second")]

    public float thresholdReductionEverySecond = 1f;
    [Tooltip("How long the ability lasts once activated")]
    public float activeDuration;

    public GameObject vfxPrefab;


    private float currentThreshold;
    private float remainingDuration;

    
    //True when stacks are more than 0  (Used by UI)
    [HideInInspector] public bool isBuildingUp;
    //True when effect is activated  (Used by UI)
    [HideInInspector] public bool isEffectActive;*/

}
