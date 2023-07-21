using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerSonic : MonoBehaviour
{
    public static SceneManagerSonic Instance;

    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
   
    }




    public void LoadMapBuilderScene(int sonicLevelNumber)
    {
        SceneManager.LoadScene("Level 1");

        PlayerPrefs.SetInt("sonicLevel", sonicLevelNumber);
    }
   
    public void LoadSonicMainMenu()
    {
        SceneManager.LoadScene("SonicMainMenu");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameSelectMenu()
    {
        SceneManager.LoadScene("GameSelectMenu");
    }
     public bool IsLastLevel()
    {
        bool isLastLevel = false;

        if(SceneManager.GetSceneByName("Level 30").isLoaded)
        {
            isLastLevel = true;
        }
        else
        {
            isLastLevel = false;
        }

        return isLastLevel;
    }
    

   
}
