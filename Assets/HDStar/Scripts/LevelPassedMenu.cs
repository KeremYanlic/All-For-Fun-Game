using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class LevelPassedMenu : MonoBehaviour
{
    public static LevelPassedMenu Instance;



    public event Action<LevelPassedMenu> OnLevelPassed;
    

    #region Button and Image Variables
    private Button nextLevelBtn;
    private Button levelSelectBtn;
    private Button gameSelectBtn;

    private Image leftStar;
    private Image middleStar;
    private Image rightStar;
    #endregion

    [SerializeField] private float yPosition;
    public bool callOnce;
    private void Awake()
    {
        Instance = this;


        #region Button and Image Introduction
        nextLevelBtn = transform.Find("nextLevelBtn").GetComponent<Button>();
        levelSelectBtn =transform.Find("levelSelectBtn").GetComponent<Button>();
        gameSelectBtn = transform.Find("gameSelectBtn").GetComponent<Button>();

        leftStar = transform.Find("leftStar").GetComponent<Image>();
        middleStar = transform.Find("middleStar").GetComponent<Image>();
        rightStar = transform.Find("rightStar").GetComponent<Image>();
        #endregion

        #region Button Click Events

        nextLevelBtn.onClick.AddListener(() => { LeanTweenMovement(gameObject, 1100, 1f);  BuildNextLevel(); IncreaseCanvasSortingOrder(GetComponentInParent<Canvas>(), 2); });
        levelSelectBtn.onClick.AddListener(() => { HDLevelTransition.Instance.LoadHDStarLevelMenu(); });
        gameSelectBtn.onClick.AddListener(() => { HDLevelTransition.Instance.LoadGameMainMenu(); });
        #endregion
    }

    private void OnEnable()
    {
        OnLevelPassed += LevelPassedMenu_OnLevelPassed;
    }
    private void OnDisable()
    {
        OnLevelPassed -= LevelPassedMenu_OnLevelPassed;
    }
   

    // Update is called once per frame
    void Update()
    {
        if (HDGameManager.Instance.SectionPassedCompleted())
        {
            if (callOnce)
            {
                CallLevelPassed();
                IncreaseCanvasSortingOrder(GetComponentInParent<Canvas>(), 60);
                ArrangeMenuStarHeader();

                callOnce = false;
            }

        }
    }

    private void BuildNextLevel()
    {




        leftStar.gameObject.SetActive(false);
        middleStar.gameObject.SetActive(false);
        rightStar.gameObject.SetActive(false);

        


        int currentLevelIndex = HDGameManager.Instance.levelIndex;
        if(currentLevelIndex != 20)
        {
            ManageLevelRewardSystem(currentLevelIndex);
            currentLevelIndex++;
            HDStarLevelBuilder.Instance.BuildHDStarLevel(currentLevelIndex);
            HDGameManager.Instance.levelIndex++;

            if (currentLevelIndex >= PlayerPrefs.GetInt("hdLevelReached"))
            {
                PlayerPrefs.SetInt("hdLevelReached", currentLevelIndex);
            }
        }
        else
        {
            ManageLevelRewardSystem(currentLevelIndex);
            if (currentLevelIndex >= PlayerPrefs.GetInt("hdLevelReached"))
            {
                PlayerPrefs.SetInt("hdLevelReached", currentLevelIndex);
            }
            HDLevelTransition.Instance.LoadHDStarLevelMenu();
        }

       
       
        callOnce = true;
    }
    private void CallLevelPassed()
    {
        OnLevelPassed?.Invoke(this);
    }
    private void LevelPassedMenu_OnLevelPassed(LevelPassedMenu levelPassedMenu)
    {
        LeanTweenMovement(gameObject, yPosition, 1f);
    }
    private void LeanTweenMovement(GameObject gameobject,float localY,float time)
    {
        LeanTween.moveLocalY(gameobject, localY, time);
    }
    private void IncreaseCanvasSortingOrder(Canvas canvas, int sortingOrder)
    {
        canvas.sortingOrder = sortingOrder;
    }

    private void ArrangeMenuStarHeader()
    {
        int rewardStarCount = Countdown.Instance.GetPrizeStarCounts();

        if(rewardStarCount == 3)
        {
            leftStar.gameObject.SetActive(true);
            middleStar.gameObject.SetActive(true);
            rightStar.gameObject.SetActive(true);
        }
        else if(rewardStarCount == 2)
        {
            leftStar.gameObject.SetActive(true);
            middleStar.gameObject.SetActive(true);
            rightStar.gameObject.SetActive(false);
        }
        else if(rewardStarCount == 1)
        {
            leftStar.gameObject.SetActive(true);
            middleStar.gameObject.SetActive(false);
            rightStar.gameObject.SetActive(false);
        }
    }
    private void ManageLevelRewardSystem(int levelIndex)
    {
        int rewardStarCount = Countdown.Instance.GetPrizeStarCounts();
        if (rewardStarCount >= PlayerPrefs.GetInt("HDLevel" + levelIndex + "RewardCount", 0))
        {
            PlayerPrefs.SetInt("HDLevel" + levelIndex + "RewardCount", rewardStarCount);
        }
        else
        {
            PlayerPrefs.SetInt("HDLevel" + levelIndex + "RewardCount", PlayerPrefs.GetInt("HDLevel" + levelIndex + "RewardCount", 0));
        }


    }

}
