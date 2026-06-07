using UnityEngine;
using UnityEngine.UI;

public class StatusEffectUIInstance : MonoBehaviour
{
    [SerializeField]Image _icon;
    [SerializeField]Image _activeStacksFill;
    public float targetStacksFillAmount;
    public float stacksLerpSpeed = 0.2f;
    [SerializeField]Image _statusBackground;

    public Image icon { get { return _icon; } set { _icon = value; } }
    public Image activeStacksFill { get { return _activeStacksFill; } set { _activeStacksFill = value; } }
    public Image statusBackground { get { return _statusBackground; } set { _statusBackground = value; } }
    private void Update()
    {
        UpdateActiveStacksFill();
    }
    public void UpdateActiveStacksFill()
    {
        _activeStacksFill.fillAmount = Mathf.Lerp(_activeStacksFill.fillAmount, targetStacksFillAmount, stacksLerpSpeed);
    }
}
