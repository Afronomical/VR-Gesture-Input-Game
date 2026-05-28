using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]Health health;
    [SerializeField] Image healthBar;
    [SerializeField] Image laggedHealthBar;

    [SerializeField] float targetHealth;
    [SerializeField] float laggingHealth;
    [SerializeField] float lagSpeed = 1;

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
        healthBar.fillAmount = targetHealth;

        laggedHealthBar.fillAmount = Mathf.Lerp(laggedHealthBar.fillAmount, targetHealth, lagSpeed);
    }
    void FaceTheCamera()
    {
        
            transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        
    }
}
