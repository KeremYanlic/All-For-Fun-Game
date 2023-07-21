using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
public class HDLevelManager : SingletonMonobehaviour<HDLevelManager>
{
    private Canvas canvas;
    private TextMeshProUGUI gameHeaderText;
    private TextMeshProUGUI hiddenStarText;

    private Button rightArrowBtn;
    private Button leftArrowBtn;

    [SerializeField] private float leftArrayLocalX;
    [SerializeField] private float leftArrayLocalScene;
    [SerializeField] private float rightArrayLocalX;
    [SerializeField] private float rightArrayLocalScene;
    [SerializeField] private float dragSpeed;

    public List<Button> Levels;
    [SerializeField] private GameObject leftArray;
    [SerializeField] private GameObject rightArray;
    private GameObject currentArray;
    private Button chooseGameBtn;

 
    public bool isRight;

   
   
    // Start is called before the first frame update
    void Start()
    {
        #region START ARRANGEMENTS
        StartArrangements();
        currentArray = leftArray;

  
        
        #endregion
    }
    // Update is called once per frame
    void Update()
    {
        LevelRewardArranger();
    }
  
   
    private void Definitions()
    {
        #region DEFINITON PART
        canvas = gameObject.GetComponentInParent<Canvas>();
        gameHeaderText = canvas.transform.Find("gameHeaderText").gameObject.GetComponent<TextMeshProUGUI>();
        hiddenStarText = canvas.transform.Find("hiddenStarText").gameObject.GetComponent<TextMeshProUGUI>();


        rightArrowBtn = transform.Find("rightArrowBtn").GetComponent<Button>();
        leftArrowBtn = transform.Find("leftArrowBtn").GetComponent<Button>();

        //leftArray = transform.Find("leftArray").gameObject;
        //rightArray = transform.Find("rightArray").gameObject;
        currentArray = transform.Find("currentArray").gameObject;

        chooseGameBtn = transform.Find("chooseGameBtn").GetComponent<Button>();

        #endregion

    }
    private void BtnMenuArranges()
    {
        #region Button Activities

        leftArrowBtn.onClick.AddListener(() => {
            if (currentArray == leftArray)
            {
                return;
            }
            else if (currentArray == rightArray)
            {
                currentArray = leftArray;
                DragArray(leftArray, leftArrayLocalScene);
                DragArray(rightArray, rightArrayLocalX);
            }
        });



        rightArrowBtn.onClick.AddListener(() => {
            if (currentArray == rightArray)
            {
                return;
            }
            else if (currentArray == leftArray)
            {
                currentArray = rightArray;
                DragArray(leftArray, leftArrayLocalX);
                DragArray(rightArray, rightArrayLocalScene);
            }
        });

        chooseGameBtn.onClick.AddListener(() => { LoadGameSelectMenu(); });
        #endregion Button Activities
    }

    private void StartArrangements()
    {
        Definitions();
        LevelInterfaceArranger();
        BtnMenuArranges();
        LeanTweenScaleAnims();
    }

    private void LevelRewardArranger()
    {
        for (int i = 1; i <= Levels.Count; i++)
        {
            if (GameObject.Find("level " + i).gameObject.activeInHierarchy)
            {
                GameObject.Find("level " + i).GetComponent<LevelMenuBtnManager>().rewardStarCount = PlayerPrefs.GetInt("HDLevel" + i + "RewardCount", 0);
            }
            else
            {
                return;
            }

        }
    }
    private void LevelInterfaceArranger()
    {
        int hdLevelReached = PlayerPrefs.GetInt("hdLevelReached", 1);


        for (int i = 1; i < Levels.Count; i++)
        {
            if (i + 1 > hdLevelReached)
            {
                Levels[i].interactable = false;
                Levels[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
            else
            {
                Levels[i].interactable = true;
                Levels[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().enabled = true;

            }
        }
    }

    public void LoadLevelYouWant(int index)
    {
        SceneManager.LoadScene("HDLevel1");

        PlayerPrefs.SetInt("hdLevel", index);
    }
    private void LoadGameSelectMenu()
    {
        SceneManager.LoadScene("GameSelectMenu");
    }

    private void LeanTweenScaleAnims()
    {
        LeanTweenScale(gameHeaderText.gameObject, new Vector2(1f, 1f), 1f);
        LeanTweenScale(hiddenStarText.gameObject, new Vector2(1f, 1f), 1f);
        LeanTweenScale(leftArrowBtn.gameObject, new Vector2(1f, 1f), 1f);
        LeanTweenScale(rightArrowBtn.gameObject, new Vector2(1f, 1f), 1f);

        for(int i = 0; i<Levels.Count; i++)
        {
            LeanTweenScale(Levels[i].gameObject, new Vector2(1f, 1f), 1f);
        }

        LeanTweenScale(chooseGameBtn.gameObject, new Vector2(1f, 1f), 1f);
    }
    



    private void DragArray(GameObject array, float xValue)
    {
        LeanTween.moveLocalX(array, xValue, dragSpeed);
    }


    private void LeanTweenScale(GameObject objectToScale,Vector2 sizeToScale,float scaleSpeed)
    {
        LeanTween.scale(objectToScale, sizeToScale, scaleSpeed).setEaseInBounce();
    }

    private void OnApplicationQuit()
    {
       PlayerPrefs.SetInt("hdLevelReached", 0);

        for (int i = 1; i <= Levels.Count; i++)
        {
            PlayerPrefs.SetInt("HDLevel" + i + "RewardCount", 0);

        }
    }
}
