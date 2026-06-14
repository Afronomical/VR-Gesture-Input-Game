using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField]AudioMixer audioMixer;

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("masterVol", Mathf.Log10(level) * 20f);
    }
    public void SetSoundVolume(float level)
    {
        audioMixer.SetFloat("soundFXVol", Mathf.Log10(level) * 20f);
    }
    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVol", Mathf.Log10(level) * 20f);
    }
    public void Volume(float level)
    {
        
    }
}
