using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TalentTree : MonoBehaviour
{
    public Tooltip toolt;
    public int activeRaws = 1;
    public int spentPoints = 0;

    private ClassScript classScript;

    void Awake()
    {
        classScript = GameObject.FindObjectOfType<ClassScript>();

        Transform raw = transform.GetChild(7);
        foreach (Transform current in raw)
        {
            if (current.GetComponent<Ability>().abilityDependency == null)
            {
                current.gameObject.GetComponent<Ability>().SetAvailable(true);
            }
        }
    }

    void Start()
    {
        SetNextRawAvailable();
    }

    void Update()
    {
        HideIfClickedOutside(toolt);
    }

    public void ShowTooltip()
    {
        toolt.gameObject.SetActive(!toolt.gameObject.activeSelf);
    }

    public void SetNextRawAvailable()
    {// Find a better way for this
        if (spentPoints < 5)
        {
            transform.GetChild(7).GetComponent<TalentRaw>().SetAbilitiesAvailable();
            activeRaws = 1;
        }
        if (spentPoints >= 5)
        {
            transform.GetChild(6).GetComponent<TalentRaw>().SetAbilitiesAvailable();
            activeRaws = 2;
        }
        else if (spentPoints < 5)
        {
            transform.GetChild(6).GetComponent<TalentRaw>().DisableAbilities();
            transform.GetChild(7).GetComponent<TalentRaw>().SetAbilitiesAvailable();
            activeRaws = 1;
        }
        if (spentPoints >= 10)
        {
            transform.GetChild(5).GetComponent<TalentRaw>().SetAbilitiesAvailable();
            activeRaws = 3;
        }
        else if (spentPoints < 10)
        {
            transform.GetChild(5).GetComponent<TalentRaw>().DisableAbilities();
        }
        if (spentPoints >= 15)
        {
            transform.GetChild(4).GetComponent<TalentRaw>().SetAbilitiesAvailable();
            activeRaws = 4;
        }
        else if (spentPoints < 15)
        {
            transform.GetChild(4).GetComponent<TalentRaw>().DisableAbilities();
        }
        if (spentPoints >= 20)
        {
            transform.GetChild(3).GetComponent<TalentRaw>().SetAbilitiesAvailable();
            activeRaws = 5;
        }
        else if (spentPoints < 20)
        {
            transform.GetChild(3).GetComponent<TalentRaw>().DisableAbilities();
        }
        if (spentPoints >= 25)
        {
            transform.GetChild(2).GetComponent<TalentRaw>().SetAbilitiesAvailable();
            activeRaws = 6;
        }
        else if (spentPoints < 25)
        {
            transform.GetChild(2).GetComponent<TalentRaw>().DisableAbilities();
        }
        if (spentPoints >= 30)
        {
            transform.GetChild(1).GetComponent<TalentRaw>().SetAbilitiesAvailable();
            activeRaws = 7;
        }
        else if (spentPoints < 30)
        {
            transform.GetChild(1).GetComponent<TalentRaw>().DisableAbilities();
        }
    }

    public int GetRawPointsSum(int raw)
    {
        return transform.GetChild(raw).GetComponent<TalentRaw>().RawPoints();
    }

    public void IncreaseSpentPoints()
    {
        spentPoints++;
        // Find a better way for this
        SetNextRawAvailable();
    }

    public void DecreaseSpentPoints()
    {
        spentPoints--;
        // Find a better way for this
        SetNextRawAvailable();
    }

    public void ResetTree()
    { // Use this method in ClassScript aswell
        ClassScript.spentPoints -= spentPoints;
        ClassScript.requiredLevel -= spentPoints;
        ClassScript.availableTalentPoints += spentPoints;
        spentPoints = 0;
        activeRaws = 1;

        for (int j = 7; j > 0; j--)
        {
            Transform currentRaw = transform.GetChild(j);
            for (int k = currentRaw.childCount - 1; k >= 0; k--)
            {
                Transform currentAbility = currentRaw.GetChild(k);
                currentAbility.GetComponent<Ability>().points = 0;
                currentAbility.GetComponent<Ability>().UpdateElements();
                currentAbility.GetComponent<Ability>().UpdatePoints();
            }
        }

        SetNextRawAvailable();
        classScript.SetTexts();
    }

    private void HideIfClickedOutside(Tooltip panel)
    {
        if (Input.GetMouseButton(0) && panel.gameObject.activeSelf && !RectTransformUtility.RectangleContainsScreenPoint(
            panel.gameObject.GetComponent<RectTransform>(),
                Input.mousePosition))
        {
            panel.gameObject.SetActive(false);
        }
    }

    private void SetRawActive(int raw)
    {
        transform.GetChild(raw).GetComponent<TalentRaw>().SetAbilitiesAvailable();
    }

    private void DisableRaw(int raw)
    {
        transform.GetChild(raw).GetComponent<TalentRaw>().DisableAbilities();
    }
}
