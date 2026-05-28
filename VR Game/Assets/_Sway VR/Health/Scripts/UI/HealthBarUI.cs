using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] Health health;

    [SerializeField] Image healthBar;
    [SerializeField] Image healthBarTrail;

    float targetHealth;
    [SerializeField] float healthFillSpeed = 10f;
    
    [SerializeField] float trailFillSpeed = 2f;

    

    

    private void Start()
    {
        
    }

    private void Update()
    {
        UpdateHealthBar();  
    }
    void UpdateHealthBar()
    {
        targetHealth = health.GetHealthPercentage() / 100;
        

        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, targetHealth, healthFillSpeed * Time.deltaTime);
        healthBarTrail.fillAmount = Mathf.Lerp(healthBarTrail.fillAmount, targetHealth, trailFillSpeed * Time.deltaTime);
    }
    
    
    
}
