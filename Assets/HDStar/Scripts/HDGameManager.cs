using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HDGameManager : MonoBehaviour
{
    public static HDGameManager Instance { get; private set; }


    public int levelIndex;
    private void Awake()
    {
        Instance = this;


        levelIndex = PlayerPrefs.GetInt("hdLevel", 1);
      
    }
    private void Start()
    {
        HDStarLevelBuilder.Instance.BuildHDStarLevel(levelIndex);
    }
    private void Update()
    {
       
        
    }
    public bool SectionPassedCompleted()
    {
        
        return OnPressStar.Instance.MissionCompleted() && !Countdown.Instance.IsCountDownZero();
        
       
    }
    public bool SectionPassedFailed()
    {
        
        return !OnPressStar.Instance.MissionCompleted() && Countdown.Instance.IsCountDownZero();
    }

    
}
