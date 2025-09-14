using UnityEngine;

public class RainSummon_Ability : Ability
{
    [SerializeField] GameObject rainGO;
    bool canFire = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GestureManager.OnGestureStarted += NextStep;

        rainGO.SetActive(false);
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

            rainGO.SetActive(true);
        }
        else
        {
            rainGO.SetActive(false);
        }
    }
}
