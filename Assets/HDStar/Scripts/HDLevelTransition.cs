using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HDLevelTransition : MonoBehaviour
{
    public static HDLevelTransition Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadHDStarLevelMenu()
    { 
        SceneManager.LoadScene("HDStarLevelMenu");
    }
    public void LoadGameMainMenu()
    {
        SceneManager.LoadScene("GameSelectMenu");
    }
 
}
