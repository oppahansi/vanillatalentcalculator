using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClassScript : MonoBehaviour
{
    public static int requiredLevel = 9;
    public static int spentPoints = 0;
    public static int availableTalentPoints = 51;

    public string className;
    public GameObject requiredLevelText;
    public GameObject spentPointsText;
    public GameObject treeOne;
    public GameObject treeTwo;
    public GameObject treeThree;

    private string warriorBaseUrl = "http://armory.twinstar.cz/talent-calc.php?cid=1&d=vanilla&tal=";
    private string warlockBaseUrl = "http://armory.twinstar.cz/talent-calc.php?cid=9&d=vanilla&tal=";
    private string shamankBaseUrl = "http://armory.twinstar.cz/talent-calc.php?cid=7&d=vanilla&tal=";
    private string rogueBaseUrl = "http://armory.twinstar.cz/talent-calc.php?cid=4&d=vanilla&tal=";
    private string priestBaseUrl = "http://armory.twinstar.cz/talent-calc.php?cid=5&d=vanilla&tal=";
    private string paladinBaseUrl = "http://armory.twinstar.cz/talent-calc.php?cid=2&d=vanilla&tal=";
    private string mageBaseUrl = "http://armory.twinstar.cz/talent-calc.php?cid=8&d=vanilla&tal=";
    private string HunterBaseUrl = "http://armory.twinstar.cz/talent-calc.php?cid=3&d=vanilla&tal=";
    private string druidBaseUrl = "http://armory.twinstar.cz/talent-calc.php?cid=11&d=vanilla&tal=";

    // Use this for initialization
    void Start()
    {
        SetTexts();
    }

    public void SetTexts()
    {
        if (requiredLevel == 9)
        {
            requiredLevelText.GetComponent<Text>().text = "Required Level: -";
        }
        else
        {
            requiredLevelText.GetComponent<Text>().text = "Required Level: " + requiredLevel.ToString();
        }

        spentPointsText.GetComponent<Text>().text = "Spent Poins: " + spentPoints.ToString();
    }

    public void SwitchToOne()
    {
        treeOne.SetActive(true);
        treeTwo.SetActive(false);
        treeThree.SetActive(false);
    }

    public void SwitchToTwo()
    {
        treeOne.SetActive(false);
        treeTwo.SetActive(true);
        treeThree.SetActive(false);
    }

    public void SwitchToThree()
    {
        treeOne.SetActive(false);
        treeTwo.SetActive(false);
        treeThree.SetActive(true);
    }

    public void OpenTalentInBrowser()
    {
        Application.OpenURL(GenerateTalentLink());
    }

    public void ResetBuild()
    { // Use ResetTree Method to remove duplicate code
        requiredLevel = 9;
        spentPoints = 0;
        availableTalentPoints = 51;

        for (int i = 0; i < 3; i++)
        {
            Transform currentTree = transform.GetChild(i);
            currentTree.GetComponent<TalentTree>().spentPoints = 0;
            currentTree.GetComponent<TalentTree>().activeRaws = 1;
            for (int j = 7; j > 0; j--)
            {
                Transform currentRaw = currentTree.GetChild(j);
                for (int k = currentRaw.childCount - 1; k >= 0; k--)
                {
                    Transform currentAbility = currentRaw.GetChild(k);
                    currentAbility.GetComponent<Ability>().points = 0;
                    currentAbility.GetComponent<Ability>().UpdateElements();
                    currentAbility.GetComponent<Ability>().UpdatePoints();
                }
            }
        }

        treeOne.GetComponent<TalentTree>().SetNextRawAvailable();
        treeTwo.GetComponent<TalentTree>().SetNextRawAvailable();
        treeThree.GetComponent<TalentTree>().SetNextRawAvailable();

        SetTexts();
    }

    public void ResetTree()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            transform.GetChild(0).GetComponent<TalentTree>().ResetTree();
        }
        else if (transform.GetChild(1).gameObject.activeSelf)
        {
            transform.GetChild(1).GetComponent<TalentTree>().ResetTree();
        }
        else if (transform.GetChild(2).gameObject.activeSelf)
        {
            transform.GetChild(2).GetComponent<TalentTree>().ResetTree();
        }
    }

    private string GenerateTalentLink()
    {
        string link = "";

        if (className.CompareTo("Warrior") == 0)
        {
            link = warriorBaseUrl + GetLinkEnd();
        }
        else if (className.CompareTo("Warlock") == 0)
        {
            link = warlockBaseUrl + GetLinkEnd();
        }
        else if (className.CompareTo("Shaman") == 0)
        {
            link = shamankBaseUrl + GetLinkEnd();
        }
        else if (className.CompareTo("Rogue") == 0)
        {
            link = rogueBaseUrl + GetLinkEnd();
        }
        else if (className.CompareTo("Priest") == 0)
        {
            link = priestBaseUrl + GetLinkEnd();
        }
        else if (className.CompareTo("Paladin") == 0)
        {
            link = paladinBaseUrl + GetLinkEnd();
        }
        else if (className.CompareTo("Mage") == 0)
        {
            link = mageBaseUrl + GetLinkEnd();
        }
        else if (className.CompareTo("Hunter") == 0)
        {
            link = HunterBaseUrl + GetLinkEnd();
        }
        else if (className.CompareTo("Druid") == 0)
        {
            link = druidBaseUrl + GetLinkEnd();
        }

        return link;
    }

    private string GetLinkEnd()
    {
        string linkEnd = "";

        for (int i = 0; i < 3; i++)
        {
            Transform currentTree = transform.GetChild(i);
            for (int j = 7; j > 0; j--)
            {
                Transform currentRaw = currentTree.GetChild(j);
                for (int k = currentRaw.childCount - 1; k >= 0; k--)
                {
                    Transform currentAbility = currentRaw.GetChild(k);
                    linkEnd += currentAbility.GetComponent<Ability>().points;
                }
            }
        }

        return linkEnd;
    }
}
