using UnityEngine;

[RequireComponent (typeof(CanvasGroup))]
public class FadeUIElements : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;


    [SerializeField] float canvasFadeSpeed = 20f;

    [SerializeField] float showHealthWithinRange = 10f;

    [SerializeField]bool isVisible;


    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup> ();
        if (isVisible)
        {
            canvasGroup.alpha = 1.0f;
        }
        else
        {
            canvasGroup.alpha = 0.0f;
        }
        
    }
    private void Update()
    {
        UpdateFadeHealthBar();
    }

    void UpdateFadeHealthBar()
    {
        if (isVisible)
        {
            ShowHealthBar();
        }
        else
        {
            FadeHealthBar();
        }
    }
    public void FadeHealthBar()
    {
        canvasGroup.alpha = Mathf.LerpUnclamped(canvasGroup.alpha, 0, canvasFadeSpeed * Time.deltaTime);
    }
    public void ShowHealthBar()
    {
        canvasGroup.alpha = Mathf.LerpUnclamped(canvasGroup.alpha, 1, canvasFadeSpeed * Time.deltaTime);

    }
}
