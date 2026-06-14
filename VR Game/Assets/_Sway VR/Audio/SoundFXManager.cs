using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;

    [SerializeField]private AudioSource soundFXPrefab;
    private void Start()
    {
        

        if(Instance == null)
        {
            Instance = this;
        }
        
    }
    public void PlayAudioClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXPrefab, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;


        Destroy(audioSource.gameObject, clipLength);
    }
    public void PlayAudioClip(AudioClip audioClip, Vector3 spawnPosition, float volume)
    {
        //AudioSource audioSource = Instantiate(soundFXPrefab, spawnPosition, Quaternion.identity);

        AudioSource audioSource = soundFXPrefab;
        audioSource.clip = audioClip;

        audioSource.volume = volume;

        float clipLength = audioClip.length;
        audioSource.PlayOneShot(audioClip);


        //Destroy(audioSource.gameObject, clipLength);
    }
}
