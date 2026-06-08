using TMPro;
using UnityEngine;

public class DamagePopUpTextUpdater : MonoBehaviour
{
    
    [SerializeField]TMP_Text dmgText;

    Color colour = Color.white;
    int Dmg;
    public void UpdateDamageText(float damage)
    {
        dmgText.text = damage.ToString();
        
    }
    public void UpdateColour(Color color)
    {
        dmgText.color = color;
    }
    protected void DestroySelf()
    {
        gameObject.SetActive(false);
    }
}
