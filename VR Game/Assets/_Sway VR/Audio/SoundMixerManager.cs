using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField]AudioMixer audioMixer;

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("masterVol", level);
    }
    public void SetSoundVolume(float level)
    {
        audioMixer.SetFloat("soundFXVol", level);
    }
    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVol", level);
    }
    public void Volume(float level)
    {
        
    }
}
