using UnityEngine;
using TMPro;

public class TutorialConsole : MonoBehaviour
{
    TutorialDisplay tutorialDisplay;
    [SerializeField] TextMeshProUGUI textBox;

    [SerializeField] Ability ability;

    private void Awake()
    {
        tutorialDisplay = FindFirstObjectByType<TutorialDisplay>();
        if(textBox!= null )
        {
            textBox.text = ability.abilityName;
        }
        
    }

    public void SetTutorialToThisAbility()
    {
        tutorialDisplay.targetedAbility = ability;
    }
    public void ToggleDisplayEnabled()
    {
        tutorialDisplay.gameObject.SetActive(!tutorialDisplay.gameObject.activeSelf);
    }
    public void UnlockAbility()
    {
        ability.enabled = true;
    }

}
