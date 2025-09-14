using UnityEngine;

public class Flamethrower_Ability : Ability
{


    [SerializeField]GameObject flamethrowerGO;
    [SerializeField] ParticleSystem flamethrowerParticleSystem;
    bool canFire = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GestureManager.OnGestureStarted += NextStep;

        flamethrowerGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ShootFlames();
    }

    void NextStep(GestureDataSO gesture)
    {
        if (!isCooldownComplete) return;

        if (gesture == requiredGestures[gestureIndex])
        {

            gestureIndex++;

            if (gestureIndex >= requiredGestures.Length)
            {
                canFire = true;
                StartCooldown();
            }

        }
        else if (gestureIndex != 0 && gesture == requiredGestures[0])
        {
            gestureIndex = 0;
            canFire = false;
        }
        
    }
    void ShootFlames()
    {
        if (gestureIndex == requiredGestures.Length && canFire)
        {
            
            flamethrowerGO.SetActive(true);
        }
        else
        {
            flamethrowerGO.SetActive(false);
        }
    }
}
