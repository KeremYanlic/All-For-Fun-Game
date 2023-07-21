using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class LevelMenuBtnManager : MonoBehaviour
{
    public event Action<LevelMenuBtnManager> StarImageAction;


    public int rewardStarCount;

    private Image oneStarImage;
    private Image twoStarImage;
    private Image threeStarImage;

   
    private void Awake()
    {
     
    }
    private void Start()
    {
        StarImageAction += LevelMenuBtnManager_StarImageAction;

        oneStarImage = gameObject.transform.Find("oneStarImage").GetComponentInChildren<Image>();
        twoStarImage = gameObject.transform.Find("twoStarImage").GetComponentInChildren<Image>();
        threeStarImage = gameObject.transform.Find("threeStarImage").GetComponentInChildren<Image>();
    }

    private void Update()
    {
       if (SceneManager.GetSceneByName("HDStarLevelMenu").isLoaded)
        {
            StarImageAction?.Invoke(this);
        }
      
        

    }
    private void LevelMenuBtnManager_StarImageAction(LevelMenuBtnManager obj)
    {
        if (rewardStarCount == 3)
        {
            oneStarImage.enabled = false;
            twoStarImage.enabled = false;
            threeStarImage.enabled = true;
        }
        if (rewardStarCount == 2)
        {
            oneStarImage.enabled = false;
            twoStarImage.enabled = true;
            threeStarImage.enabled = false;
        }
        if (rewardStarCount == 1)
        {
            oneStarImage.enabled = true;
            twoStarImage.enabled = false;
            threeStarImage.enabled = false;
        }
        if (rewardStarCount == 0)
        {
            oneStarImage.enabled = false;
            twoStarImage.enabled = false;
            threeStarImage.enabled = false;
        }
    }

}
