using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class LevelFailedMenu : MonoBehaviour
{
    public event Action<LevelFailedMenu> OnLevelFailed;



    public static LevelFailedMenu Instance;

    #region Button Variables
    private Button retryBtn;
    private Button levelSelectBtn;
    private Button gameSelectBtn;
    #endregion

    [SerializeField] private float yPosition;
    public bool callOnce;


    private void Awake()
    {
        Instance = this;


        #region Button Introduction
        retryBtn = transform.Find("retryBtn").GetComponent<Button>();
        levelSelectBtn = transform.Find("levelSelectBtn").GetComponent<Button>();
        gameSelectBtn = transform.Find("gameSelectBtn").GetComponent<Button>();
        #endregion

        #region Button Click Events

        retryBtn.onClick.AddListener(() => { LeanTweenMovement(gameObject, 1100, 1f); RetryLevel(); IncreaseCanvasSortingOrder(GetComponentInParent<Canvas>(), 2); });
        levelSelectBtn.onClick.AddListener(() => { HDLevelTransition.Instance.LoadHDStarLevelMenu(); });
        gameSelectBtn.onClick.AddListener(() => { HDLevelTransition.Instance.LoadGameMainMenu(); });
        #endregion
    }
    private void OnEnable()
    {
        OnLevelFailed += LevelFailedMenu_OnLevelFailed;
    }
    private void OnDisable()
    {
        OnLevelFailed -= LevelFailedMenu_OnLevelFailed;
    }

    private void Update()
    {
        if (HDGameManager.Instance.SectionPassedFailed())
        {
            if (callOnce)
            {
                CallLevelFailed();
                IncreaseCanvasSortingOrder(GetComponentInParent<Canvas>(), 60);
                callOnce = false;
            }

        }
    }
    private void RetryLevel()
    {


        int currentLevelIndex = HDGameManager.Instance.levelIndex;

        HDStarLevelBuilder.Instance.BuildHDStarLevel(currentLevelIndex);
       // PlayerPrefs.SetInt("hdLevel", levelIndex);

        callOnce = true;
    }
    private void CallLevelFailed()
    {
        OnLevelFailed?.Invoke(this);
    }
    private void LevelFailedMenu_OnLevelFailed(LevelFailedMenu levelFailedMenu)
    {

        LeanTweenMovement(gameObject, yPosition, 1f);
    }
    private void LeanTweenMovement(GameObject gameobject, float localY, float time)
    {
        LeanTween.moveLocalY(gameobject, localY, time);
    }
    private void IncreaseCanvasSortingOrder(Canvas canvas, int sortingOrder)
    {
        canvas.sortingOrder = sortingOrder;
    }
  

}
