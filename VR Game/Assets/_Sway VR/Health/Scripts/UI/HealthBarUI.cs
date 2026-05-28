using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Image healthBar;
    [SerializeField] Image healthEcho;

    [SerializeField] float targetHealth;
    [SerializeField] float targetHealthFillSpeed = 1f;


    
    [SerializeField] float healthEchoFillSpeed = 0.1f;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        UpdateHealthBar();
        FaceTheCamera();
    }
    void UpdateHealthBar()
    {
        targetHealth = health.GetHealthPercentage() / 100;
        

        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, targetHealth, targetHealthFillSpeed);
        healthEcho.fillAmount = Mathf.Lerp(healthEcho.fillAmount, targetHealth, healthEchoFillSpeed);
    }
    void FaceTheCamera()
    {
        
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        
    }
}
