using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public bool isLevelPassed;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    

    }
    public void LoadPuzzleLevelMenu()
    {
        SceneManager.LoadScene("PuzzleMainScene");
    }
    public void LoadGameMainMenu()
    {
        SceneManager.LoadScene("GameSelectMenu");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        int levelIndex = PlayerPrefs.GetInt("puzzleLevelReached", 0);

        if (SceneManager.GetSceneByName("PuzzleScene " + levelIndex).isLoaded)
        {
            levelIndex++;
            PlayerPrefs.SetInt("puzzleLevelReached", levelIndex);
        }


    }

    public void LastSceneLoadLevel()
    {
        SceneManager.LoadScene("PuzzleMainScene");
    }
   
}
