using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tooltip : MonoBehaviour
{
    public ClassScript classScript;
    public TalentTree tree;

    private Ability abi;

    void OnEnable()
    {    // Find a better way for this
        if (abi.treeName.CompareTo("Arms") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Arms.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Fury") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Fury.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Defensive") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Defensive.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Affliction") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Affliction.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Demonology") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Demonology.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Destruction") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Destruction.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Elemental") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Elemental.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Enhancement") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Enhancement.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Restoration") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Restoration.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Assassination") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Assassination.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Combat") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Combat.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Subtlety") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Subtlety.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Discipline") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Discipline.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Holy") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Holy.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Shadow") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Shadow.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("HolyPala") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.HolyPala.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Protection") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Protection.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Retribution") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Retribution.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Arcane") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Arcane.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Fire") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Fire.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Frost") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Frost.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Beast Mastery") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.BeastMastery.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Marksmanship") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Marksmanship.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Survival") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Survival.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Balance") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.Balance.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("Feral Combat") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.FeralCombat.AbilityNames[abi.abilityPosition];
        }
        else if (abi.treeName.CompareTo("RestorationDruid") == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = TooltipText.RestorationDruid.AbilityNames[abi.abilityPosition];
        }

        SetTooltipPosition();
        UpdatePoints();
        CheckDependenciesRequirements();
        UpdateDescriptions();

        UpdateButtons();
    }

    void OnDisable()
    {
        transform.GetChild(6).GetComponent<Text>().text = "";
        transform.GetChild(6).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
    }

    public void AddPoint()
    { // Find a better way for this
        abi.AddPoint();
        UpdatePoints();
        UpdateDescriptions();
        UpdateButtons();
        classScript.SetTexts();
    }

    public void SubPoint()
    {// Find a better way for this
        abi.SubPoint();
        UpdatePoints();
        UpdateDescriptions();
        UpdateButtons();
        classScript.SetTexts();
    }

    public void UpdatePoints()
    {
        transform.GetChild(1).GetComponent<Text>().text = "Rank " + abi.points + "/" + abi.abilityRanks;
    }

    public void UpdateDescriptions()
    {
        if (abi.abilityRanks > 0)
        {
            if (abi.points > 0 && !transform.GetChild(5).gameObject.activeSelf)
            {
                transform.GetChild(5).gameObject.SetActive(true);
            }
            if (abi.points > 0 && abi.points < abi.abilityRanks && !transform.GetChild(6).gameObject.activeSelf)
            {
                transform.GetChild(6).gameObject.SetActive(true);
            }

            // Find a better way for this
            if (abi.points > 0)
            {
                if (abi.treeName.CompareTo("Arms") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Arms.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Fury") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Fury.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Defensive") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Defensive.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Affliction") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Affliction.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Demonology") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Demonology.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Destruction") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Destruction.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Elemental") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Elemental.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Enhancement") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Enhancement.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Restoration") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Restoration.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Assassination") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Assassination.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Combat") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Combat.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Subtlety") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Subtlety.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Discipline") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Discipline.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Holy") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Holy.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Shadow") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Shadow.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("HolyPala") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.HolyPala.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Protection") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Protection.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Retribution") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Retribution.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Arcane") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Arcane.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Fire") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Fire.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Frost") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Frost.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Beast Mastery") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.BeastMastery.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Marksmanship") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Marksmanship.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Survival") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Survival.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Balance") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Balance.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("Feral Combat") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.FeralCombat.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }
                else if (abi.treeName.CompareTo("RestorationDruid") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.RestorationDruid.GetAbilityDesc(abi.abilityPosition, abi.points - 1);
                }


            }
            else // Find a better way for this
            {
                if (abi.treeName.CompareTo("Arms") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Arms.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Fury") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Fury.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Defensive") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Defensive.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Affliction") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Affliction.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Demonology") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Demonology.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Destruction") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Destruction.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Elemental") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Elemental.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Enhancement") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Enhancement.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Restoration") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Restoration.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Assassination") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Assassination.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Combat") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Combat.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Subtlety") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Subtlety.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Discipline") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Discipline.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Holy") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Holy.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Shadow") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Shadow.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("HolyPala") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.HolyPala.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Protection") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Protection.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Retribution") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Retribution.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Arcane") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Arcane.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Fire") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Fire.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Frost") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Frost.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Beast Mastery") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.BeastMastery.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Marksmanship") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Marksmanship.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Survival") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Survival.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Balance") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.Balance.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("Feral Combat") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.FeralCombat.GetAbilityDesc(abi.abilityPosition, 0);
                }
                else if (abi.treeName.CompareTo("RestorationDruid") == 0)
                {
                    transform.GetChild(4).GetComponent<Text>().text = TooltipText.RestorationDruid.GetAbilityDesc(abi.abilityPosition, 0);
                }
            }

            // Find a better way for this
            if (abi.points > 0 && abi.points < abi.abilityRanks)
            {
                if (abi.treeName.CompareTo("Arms") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Arms.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Fury") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Fury.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Defensive") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Defensive.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Affliction") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Affliction.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Demonology") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Demonology.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Destruction") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Destruction.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Elemental") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Elemental.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Enhancement") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Enhancement.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Restoration") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Restoration.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Assassination") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Assassination.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Combat") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Combat.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Subtlety") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Subtlety.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Discipline") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Discipline.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Holy") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Holy.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Shadow") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Shadow.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("HolyPala") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.HolyPala.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Protection") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Protection.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Retribution") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Retribution.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Arcane") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Arcane.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Fire") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Fire.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Frost") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Frost.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Beast Mastery") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.BeastMastery.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Marksmanship") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Marksmanship.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Survival") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Survival.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Balance") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.Balance.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("Feral Combat") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.FeralCombat.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
                else if (abi.treeName.CompareTo("RestorationDruid") == 0)
                {
                    transform.GetChild(6).GetComponent<Text>().text = TooltipText.RestorationDruid.GetAbilityDesc(abi.abilityPosition, abi.points);
                }
            }
            else
            {
                transform.GetChild(5).gameObject.SetActive(false);
                transform.GetChild(6).gameObject.SetActive(false);
            }
        }
    }

    public void UpdateButtons()
    {
        if (abi.available)
        {
            if (SubtractPossible())
            {
                transform.GetChild(7).GetComponent<Button>().interactable = true;
            }
            else
            {
                transform.GetChild(7).GetComponent<Button>().interactable = false;
            }

            if (abi.points < abi.abilityRanks && ClassScript.availableTalentPoints > 0)
            {
                transform.GetChild(8).GetComponent<Button>().interactable = true;
            }
            else
            {
                transform.GetChild(8).GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            transform.GetChild(8).GetComponent<Button>().interactable = false;
            transform.GetChild(7).GetComponent<Button>().interactable = false;
        }
    }

    public bool SubtractPossible()
    {
        if (abi.points == 0)
        {
            return false;
        }
        if (tree.spentPoints - tree.GetRawPointsSum(8 - tree.activeRaws) == (tree.activeRaws - 1) * 5 && tree.GetRawPointsSum(8 - tree.activeRaws) > 0 && IsBreakingRequirement())
        {
            return false;
        }
        if (abi.abilityFollowUp && abi.abilityFollowUp.points > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SetAbility(Ability abi)
    {
        this.abi = abi;
    }

    private bool IsBreakingRequirement()
    {
        int sum = 0;

        for (int i = 7; i > 8 - tree.activeRaws; i--)
        {
            sum += tree.GetRawPointsSum(i);
        }

        if (tree.activeRaws > 1 && abi.abilityRaw > 8 - tree.activeRaws && sum % 5 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetTooltipPosition()
    {
        Vector2 tooltipPosition = new Vector2();

        tooltipPosition.x = Screen.width / 2;
        tooltipPosition.y = Screen.height / 2;
        transform.position = tooltipPosition;
    }

    private void CheckDependenciesRequirements()
    {
        if (!abi.available)
        {
            if (abi.pointsDependency > tree.spentPoints)
            {
                transform.GetChild(2).gameObject.SetActive(true);
                transform.GetChild(2).GetComponent<Text>().text = "Requires " + abi.pointsDependency + " points in " + abi.treeName + " Talents.";
            }
            if (abi.abilityDependency != null)
            {
                if (abi.abilityDependency.points != abi.abilityDependency.abilityRanks)
                {
                    transform.GetChild(3).gameObject.SetActive(true);
                    transform.GetChild(3).GetComponent<Text>().text = "Requires " + abi.abilityDependency.abilityRanks + " points in " + abi.abilityDependency.gameObject.name + ".";
                }
            }
        }
        else
        {
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}