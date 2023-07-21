using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager2 : MonoBehaviour
{
    public static LevelManager2 Instance;

    private GameObject EveryObject;
    public Button menuButton;
    public Button restartButton;

    public GameObject mainMenu;
    public bool canDraw;

   
    private void Awake()
    {
        Instance = this;

        EveryObject = GameObject.Find("Everything");
        mainMenu.gameObject.SetActive(false);

        canDraw = true;
    }
    private void Start()
    {
        EveryObject.SetActive(true);
    }
    private void Update()
    { 
    }
    public void OpenMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        
        
    }
    public void CloseMainMenu()
    {
        mainMenu.gameObject.SetActive(false);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      
    }
    public void LoadLevelChooseSection()
    {
        LoadLevelSelectScene();

    }
    public void LoadGameChooseSection()
    {
        LoadGameChooseScene();
    }
    private void LoadLevelSelectScene()
    {
        //EveryObject.SetActive(false);
        //yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("ColoringMM");
       

    }
    private void LoadGameChooseScene()
    {
        //EveryObject.SetActive(false);
        //yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("GameSelectMenu");
       
    }

   
}
