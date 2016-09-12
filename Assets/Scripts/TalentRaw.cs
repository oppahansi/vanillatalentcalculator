using UnityEngine;
using System.Collections;

public class TalentRaw : MonoBehaviour
{
    public TalentTree tree;
    public int requiredPoints;

    private Transform[] abilities;

    void Awake()
    {
        abilities = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            abilities[i] = transform.GetChild(i);
        }
    }

    void Start()
    {
        abilities = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            abilities[i] = transform.GetChild(i);
        }
    }

    public int RawPoints()
    {
        int sum = 0;

        foreach (Transform current in abilities)
        {
            sum += current.GetComponent<Ability>().points;
        }

        return sum;
    }

    public void SetAbilitiesAvailable()
    {
        if (abilities != null)
        {
            foreach (Transform current in abilities)
            {
                if (current)
                {
                    current.gameObject.GetComponent<Ability>().SetAvailable(CheckAvailabilityStatus(current));
                }
            }
        }
    }

    public void DisableAbilities()
    {
        if (abilities != null)
        {
            foreach (Transform current in abilities)
            {
                if (current)
                {
                    current.gameObject.GetComponent<Ability>().SetAvailable(false);
                }
            }
        }
    }

    private bool CheckAvailabilityStatus(Transform current)
    {
        if (current.GetComponent<Ability>().abilityDependency || current.GetComponent<Ability>().pointsDependency > 0)
        {
            if (current.GetComponent<Ability>().abilityDependency)
            {
                if (current.GetComponent<Ability>().abilityDependency.points == current.GetComponent<Ability>().abilityDependency.abilityRanks)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (current.GetComponent<Ability>().pointsDependency > 0)
            {
                if (current.GetComponent<Ability>().pointsDependency <= tree.spentPoints)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
    }
}
