using UnityEngine;

//public enum EStatusEffectType { burn, wet, frozen, shock }

[CreateAssetMenu(fileName = "StatusFXDataSO", menuName = "SwayVR/StatusEffects/StatusFXDataSO")]

public class StatusEffectSO : ScriptableObject
{
   /* [SerializeField, Header("Status  Type"), Tooltip("Integer key for what status type this is. \n New entries can be added to the EStatusEffectType enum")]
    private EStatusEffectType status;*/

    [SerializeField, Space ,Header("UI Elements")]
    [Tooltip("The colour shown on: damagePopUps, IconBackgrounds and anywhere this element is represented")]
    private Color color = Color.white;

    [SerializeField, Tooltip("The Icon used to represent this element")]
    private Sprite icon;


    //public EStatusEffectType Status { get { return status; } }
    public Color Color { get { return color; } }
    public Sprite Icon { get { return icon; } }
    public float duration { get { return duration; } }

    public virtual void OnActivate(StatusEffectHandler handler) { }
    public virtual void OnTick(StatusEffectHandler handler) { }
    public virtual void OnDeactivate(StatusEffectHandler handler) { }




}
