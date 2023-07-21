using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class PuzzleWinMenu : MonoBehaviour
{
    public event EventHandler WinEvent;

   


    private Button nextLevelBtn;
    private Button restartBtn;
    private Button levelSelectBtn;
    private Button gameSelectBtn;

    [SerializeField] private float localYArrival;
    [SerializeField] private float arriveTime;

    private bool callOnceTime;

    private void Awake()
    {
        DefinitionPart();
        OnClickEvents();
    }

    // Start is called before the first frame update
    void Start()
    {
        WinEvent += PuzzleWinMenu_WinEvent;
        callOnceTime = true;
      
    }

   

    private void Update()
    {
        if (PuzzleManager.Instance.isLevelPassed)
        {
            CallWinEvent();
        }
    }

    private void PuzzleWinMenu_WinEvent(object sender, EventArgs e)
    {
        LeanTween.moveLocalY(this.gameObject, localYArrival, arriveTime);
    }

    public void CallWinEvent()
    {
        if (callOnceTime)
        {
            WinEvent?.Invoke(this, EventArgs.Empty);
            callOnceTime = false;
        }

    }

    private void DefinitionPart()
    {
        #region DEFINITONS
        nextLevelBtn = transform.Find("nextLevelBtn").GetComponent<Button>();
        restartBtn = transform.Find("restartBtn").GetComponent<Button>();
        levelSelectBtn = transform.Find("levelSelectBtn").GetComponent<Button>();
        gameSelectBtn = transform.Find("gameSelectBtn").GetComponent<Button>();


        #endregion
    }

    private void OnClickEvents()
    {
        #region ON CLICK EVENTS

        #region NextLevelBtn
        nextLevelBtn.onClick.AddListener(() => {
            if (SceneManager.GetSceneByName("PuzzleScene 12").isLoaded)
            {
                PuzzleManager.Instance.LastSceneLoadLevel();
            }
            else
            {
                PuzzleManager.Instance.LoadNextScene();
            }

        });
        #endregion

        #region Other Btns
        restartBtn.onClick.AddListener(() => { PuzzleManager.Instance.RestartLevel(); });
        levelSelectBtn.onClick.AddListener(() => { PuzzleManager.Instance.LoadPuzzleLevelMenu(); });
        gameSelectBtn.onClick.AddListener(() => { PuzzleManager.Instance.LoadGameMainMenu(); });
        #endregion

        #endregion
    }

}
