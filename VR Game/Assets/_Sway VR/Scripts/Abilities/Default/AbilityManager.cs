using UnityEngine;
using System.Collections.Generic;
public class AbilityManager : MonoBehaviour
{
    [SerializeField] List<Ability> abilities;

    public GameObject player;

    

    public void AddAbility(Ability ability)
    {
        if (!abilities.Contains(ability))
        {
            ability.Initialize(this);
            abilities.Add(ability);
        }
    }
    public void RemoveAbility(Ability ability)
    {
        if(abilities.Contains(ability))
        {
            abilities.Remove(ability);
        }
    }

    public void SetActive(Ability ability, bool newActiveState)
    {
        if(abilities.Contains(ability))
        {
            ability.SetActive(newActiveState);
        }
    }

    public void DisableAllAbilities()
    {
        foreach(Ability ability in abilities)
        {
            ability.SetActive(false);
        }
    }

    public void EnableAllAbilities()
    {
        foreach(Ability ability in abilities)
        {
            ability.SetActive(true);
        }
    }
}
