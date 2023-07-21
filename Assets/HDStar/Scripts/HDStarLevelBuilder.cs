using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(StarSpawner))]
[DisallowMultipleComponent]
public class HDStarLevelBuilder : MonoBehaviour
{
    public static HDStarLevelBuilder Instance;


    [SerializeField] private HDStarSO HDStarImageSO;
    

    private StarSpawner starSpawner;
    [SerializeField] private int countDownStarTime = 30;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
        starSpawner = GetComponent<StarSpawner>();
    }

    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildHDStarLevel(int index)
    {
        
        BuildBGImage(index - 1);
        SpawningStars(HDStarImageSO);
        OnPressStar.Instance.CallOnBuildLevelEvent(0, -1);
        StarControlPanel.Instance.StarControlPanelProcess();
        Countdown.Instance.CallOnBuildLevelEvent(countDownStarTime);
        
       
    }
    private void BuildBGImage(int index)
    {
        Canvas canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        Image generalBG = canvas.gameObject.transform.Find("generalBG").GetComponent<Image>();

        int ind = index;
      

        if(ind >= 0 && index <= 20)
        {
            generalBG.sprite = HDStarImageSO.bgImageList[ind];
        }
        else
        {
            HDLevelTransition.Instance.LoadHDStarLevelMenu();
        }
    }
    private void SpawningStars(HDStarSO hDStarSO)
    {
        starSpawner.ClearContainer();


        starSpawner.InitialiseStars(hDStarSO);
    }


}
