using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreenManager : MonoBehaviour
{
    ScreenManager screenManager;

    void Awake()
    {
        if (screenManager == null)
        {
            screenManager = this;
            DontDestroyOnLoad(screenManager);
        }
        else
        {
            DestroyImmediate(screenManager);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name.CompareTo("Menu") == 0)
            {
                Application.Quit();
            }
            else
            {
                if (SceneManager.GetActiveScene().name.CompareTo("Druid") == 0 ||
                    SceneManager.GetActiveScene().name.CompareTo("Hunter") == 0 ||
                    SceneManager.GetActiveScene().name.CompareTo("Mage") == 0 ||
                    SceneManager.GetActiveScene().name.CompareTo("Paladin") == 0 ||
                    SceneManager.GetActiveScene().name.CompareTo("Priest") == 0 ||
                    SceneManager.GetActiveScene().name.CompareTo("Rogue") == 0 ||
                    SceneManager.GetActiveScene().name.CompareTo("Shaman") == 0 ||
                    SceneManager.GetActiveScene().name.CompareTo("Warlock") == 0 ||
                    SceneManager.GetActiveScene().name.CompareTo("Warrior") == 0)
                {
                    LoadScreen("Menu");
                }
            }
        }
    }

    public void LoadScreen(string name)
    {
        SceneManager.LoadScene(name);
    }
}
