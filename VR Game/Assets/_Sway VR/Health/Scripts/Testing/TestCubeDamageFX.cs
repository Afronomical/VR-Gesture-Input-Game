using UnityEngine;

public class TestCubeDamageFX : MonoBehaviour
{
    enum E_HealthStates
    {
        dead,
        hurt,
        fullHealth
    }
    public Health health;

    public GameObject initialDeathParticles;
    public GameObject hurtParticles;
    public GameObject deathParticles;
    public GameObject harmedParticles;

    public bool isNewHealthState;

    E_HealthStates healthState = E_HealthStates.fullHealth;
    E_HealthStates previousHealthState = E_HealthStates.fullHealth;

    private void Start()
    {
        TryGetComponent<Health>(out health);
        health.OnDeath += DeathBurnFX;
        health.OnHarmed += HarmedFX;
    }

    private void Update()
    {
        SetHealthState();

        isNewHealthState = healthState != previousHealthState;


        previousHealthState = healthState;
    }
    bool GetIsNewHealthState()
    {

        return isNewHealthState;
    }
    void SetHealthState()
    {
        if(health.GetHealthPercentage() >= 100)
        {
            healthState = E_HealthStates.fullHealth;
        }
        else if(health.GetHealthPercentage() <= 0 )
        {
            healthState = E_HealthStates.dead;
        }
        else
        {
            healthState = E_HealthStates.hurt;
        }

        if (GetIsNewHealthState())
        {
            switch (healthState)
            {
                case E_HealthStates.dead:
                    hurtParticles.GetComponent<ParticleSystem>().Stop();
                    deathParticles.GetComponent<ParticleSystem>().Play();
                    break;
                case E_HealthStates.hurt:
                    hurtParticles.GetComponent<ParticleSystem>().Play();
                    deathParticles.GetComponent<ParticleSystem>().Stop();
                    break;
                case E_HealthStates.fullHealth:
                    hurtParticles.GetComponent<ParticleSystem>().Stop();
                    deathParticles.GetComponent<ParticleSystem>().Stop();
                    break;
                default:
                    break;
            }
        }
    }
    void DeathBurnFX()
    {
        initialDeathParticles.GetComponent<ParticleSystem>().Play();
    }
    void HarmedFX()
    {
        harmedParticles.GetComponent<ParticleSystem>().Play();
    }

}
