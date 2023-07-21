using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public Button playButton;
    public GameObject firstMenu;
    public GameObject secondMenu;
    private void Awake()
    {
        Instance = this;

        firstMenu.SetActive(true);
        secondMenu.SetActive(false);

    }
    public void ActivatingSecondMenu()
    {
        firstMenu.SetActive(false);
        secondMenu.SetActive(true);
        ColoringMMM.Instance.LeanTweenScaleAnim();
    }
    public void OpeningFirstScene()
    {
        FirstSceneArrangements();
    }
    public void OpeningSecondScene()
    {
        SecondSceneArrangements();
    }
    public void OpeningThirdScene()
    {
        ThirdSceneArrangements();
    }
    public void OpeningFourthScene()
    {
        FourthSceneArrangements();
    }

    private void FirstSceneArrangements()
    {
        firstMenu.SetActive(false);
        secondMenu.SetActive(false);
        SceneManager.LoadScene("DrawMeshFull");
       
    }
    private void SecondSceneArrangements()
    {

        firstMenu.SetActive(false);
        secondMenu.SetActive(false);
        SceneManager.LoadScene("DrawMeshFull 1");
       
    }
    private void ThirdSceneArrangements()
    {

        firstMenu.SetActive(false);
        secondMenu.SetActive(false);
        SceneManager.LoadScene("DrawMeshFull 2");
        
    }
    private void FourthSceneArrangements()
    {

        firstMenu.SetActive(false);
        secondMenu.SetActive(false);
        SceneManager.LoadScene("DrawMeshFull 3");
        
    }
    public void LoadGameSelectMenu()
    {
        SceneManager.LoadScene("GameSelectMenu");
    }

   
}
