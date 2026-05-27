using UnityEngine;

public interface IStatusEffectable
{
    abstract void ApplyEffect(StatusEffectData data);

    abstract void RemoveEffect(StatusEffectData data);
}
