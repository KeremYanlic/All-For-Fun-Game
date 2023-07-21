using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingMenu : MonoBehaviour
{
   

    public Button settingBtn;
    private Button continueBtn;
    private Button levelSelectBtn;
    private Button gameSelectBtn;
    private Button closeBtn;

    [SerializeField] private float localYArrival;
    [SerializeField] private float localYDeparture;
    [SerializeField] private float arriveTime;

    [SerializeField] private DragAndDrop dragAndDrop;
    [SerializeField] private bool isJigsaw;

   
    private void Awake()
    {
        SetAllowToPuzzleTrue();


        continueBtn = transform.Find("continueBtn").GetComponent<Button>();
        levelSelectBtn = transform.Find("levelSelectBtn").GetComponent<Button>();
        gameSelectBtn = transform.Find("gameSelectBtn").GetComponent<Button>();
        closeBtn = transform.Find("closeBtn").GetComponent<Button>();



        settingBtn.onClick.AddListener(() => { SetAllowToPuzzleFalse(); LeanTween.moveLocalY(gameObject, localYArrival, arriveTime); IncreaseCanvasSortingOrder(GetComponentInParent<Canvas>(), 100);  });
        continueBtn.onClick.AddListener(() => { LeanTween.moveLocalY(gameObject, localYDeparture, arriveTime).setOnComplete(SetAllowToPuzzleTrue); IncreaseCanvasSortingOrder(GetComponentInParent<Canvas>(), 0);  });
        closeBtn.onClick.AddListener(() => { LeanTween.moveLocalY(gameObject, localYDeparture, arriveTime).setOnComplete(SetAllowToPuzzleTrue); IncreaseCanvasSortingOrder(GetComponentInParent<Canvas>(), 0); });


        if (!isJigsaw)
        {
            levelSelectBtn.onClick.AddListener(() => { HDLevelTransition.Instance.LoadHDStarLevelMenu();  });
            gameSelectBtn.onClick.AddListener(() => { HDLevelTransition.Instance.LoadGameMainMenu(); });
        }
        else
        {
            levelSelectBtn.onClick.AddListener(() => { PuzzleManager.Instance.LoadPuzzleLevelMenu(); });
            gameSelectBtn.onClick.AddListener(() => { PuzzleManager.Instance.LoadGameMainMenu(); });
        }
       
    }
  
    private void IncreaseCanvasSortingOrder(Canvas canvas, int sortingOrder)
    { 
       canvas.sortingOrder = sortingOrder;
    }
   
   
    private void SetAllowToPuzzleTrue()
    {
        if (isJigsaw)
        {
            dragAndDrop.allowToPuzzle = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    private void SetAllowToPuzzleFalse()
    {
        if (isJigsaw)
        {
            dragAndDrop.allowToPuzzle = false;
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
