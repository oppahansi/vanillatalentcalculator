using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ability : MonoBehaviour
{
    public TalentTree tree;
    public Ability abilityDependency;
    public Ability abilityFollowUp;
    public Ability abilityFollowTwo;
    public int abilityRanks;
    public int abilityPosition;
    public int abilityRaw;
    public int pointsDependency;
    public int points = 0;
    public bool hasAbilityDependency;
    public bool isAbilityFollowUpDown;
    public bool isAbilityFollowUpDownOne;
    public bool isAbilityFollowUpDownTwo;
    public bool isAbilityFollowUpRight;
    public bool isAbilityFollowUpRightDown;
    public bool available = false;
    public string treeName;

    void Start()
    {
        SetArrows();
    }

    public void SetAvailable(bool available)
    {
        this.available = available;

        UpdateSpell();
        UpdateElements();
        UpdatePoints();
        SetArrows();
    }

    public void AddPoint()
    {
        if (points < abilityRanks)
        {
            points++;
            tree.IncreaseSpentPoints();
            ClassScript.spentPoints++;
            ClassScript.requiredLevel++;
            ClassScript.availableTalentPoints--;

            if (points == abilityRanks)
            {
                if (abilityFollowUp)
                {
                    tree.SetNextRawAvailable();
                    abilityFollowUp.SetArrows();
                }

                if (abilityFollowTwo)
                {
                    tree.SetNextRawAvailable();
                    abilityFollowTwo.SetArrows();
                }
            }

            UpdatePoints();
            SetArrows();
        }
    }

    public void SubPoint()
    {
        if (points > 0)
        {
            points--;
            tree.DecreaseSpentPoints();
            ClassScript.spentPoints--;
            ClassScript.requiredLevel--;
            ClassScript.availableTalentPoints++;

            if (points < abilityRanks)
            {

                if (abilityFollowUp)
                {
                    tree.SetNextRawAvailable();
                    abilityFollowUp.SetArrows();
                }

                if (abilityFollowTwo)
                {
                    tree.SetNextRawAvailable();
                    abilityFollowTwo.SetArrows();
                }
            }

            UpdatePoints();
            SetArrows();
        }
    }

    public void UpdateSpell()
    {
        if (available)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    public void SetArrows()
    {
        if (isAbilityFollowUpDown)
        {
            if (available && abilityDependency && abilityDependency.abilityRanks == abilityDependency.points && pointsDependency <= tree.spentPoints)
            {
                transform.GetChild(5).gameObject.SetActive(false);
                transform.GetChild(6).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(5).gameObject.SetActive(true);
                transform.GetChild(6).gameObject.SetActive(false);
            }
        }
        else if (isAbilityFollowUpDownOne)
        {
            if (available && abilityDependency && abilityDependency.abilityRanks == abilityDependency.points && pointsDependency <= tree.spentPoints)
            {
                transform.GetChild(7).gameObject.SetActive(false);
                transform.GetChild(8).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(7).gameObject.SetActive(true);
                transform.GetChild(8).gameObject.SetActive(false);
            }
        }
        else if (isAbilityFollowUpDownTwo)
        {
            if (available && abilityDependency && abilityDependency.abilityRanks == abilityDependency.points && pointsDependency <= tree.spentPoints)
            {
                transform.GetChild(9).gameObject.SetActive(false);
                transform.GetChild(10).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(9).gameObject.SetActive(true);
                transform.GetChild(10).gameObject.SetActive(false);
            }
        }
        else if (isAbilityFollowUpRightDown)
        {
            if (available && abilityDependency && abilityDependency.abilityRanks == abilityDependency.points && pointsDependency <= tree.spentPoints)
            {
                transform.GetChild(11).gameObject.SetActive(false);
                transform.GetChild(12).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(11).gameObject.SetActive(true);
                transform.GetChild(12).gameObject.SetActive(false);
            }
        }
        else if (isAbilityFollowUpRight)
        {
            if (available && abilityDependency && abilityDependency.abilityRanks == abilityDependency.points && pointsDependency <= tree.spentPoints)
            {
                transform.GetChild(13).gameObject.SetActive(false);
                transform.GetChild(14).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(13).gameObject.SetActive(true);
                transform.GetChild(14).gameObject.SetActive(false);
            }
        }
    }

    public void UpdateElements()
    {
        if (available)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(true);
            UpdateSpell();
        }
        else
        {
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            UpdateSpell();
        }
    }

    public void UpdatePoints()
    {
        transform.GetChild(4).gameObject.GetComponent<Text>().text = points.ToString();
        if (points == abilityRanks)
        {
            transform.GetChild(2).gameObject.GetComponent<Image>().color = Color.yellow;
            transform.GetChild(4).gameObject.GetComponent<Text>().color = Color.yellow;
        }
        else
        {
            if (available)
            {
                transform.GetChild(2).gameObject.GetComponent<Image>().color = Color.green;
                transform.GetChild(4).gameObject.GetComponent<Text>().color = Color.green;
            }
            else
            {
                transform.GetChild(2).gameObject.GetComponent<Image>().color = Color.white;
            }
        }
    }
}
