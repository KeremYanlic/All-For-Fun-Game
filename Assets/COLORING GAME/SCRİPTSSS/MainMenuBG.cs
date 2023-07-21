using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuBG : MonoBehaviour
{
    [SerializeField] private Button settingBtn;
    private Button continueBtn;
    private Button levelSelectBtn;
    private Button gameSelectBtn;

    [SerializeField] private float localYArrival;
    [SerializeField] private float localYDeparture;
    [SerializeField] private float arriveTime;
    // Start is called before the first frame update

    private void Awake()
    {
        continueBtn = transform.Find("continueBtn").GetComponent<Button>();
        levelSelectBtn = transform.Find("levelSelectBtn").GetComponent<Button>();
        gameSelectBtn = transform.Find("gameSelectBtn").GetComponent<Button>();
     
        settingBtn.onClick.AddListener(() => { LeanTween.moveLocalY(gameObject, localYArrival, arriveTime).setOnComplete(CantDraw);  });
        continueBtn.onClick.AddListener(() => { LeanTween.moveLocalY(gameObject, localYDeparture, arriveTime).setOnComplete(CanDraw); });
       

        levelSelectBtn.onClick.AddListener(() => { LevelManager2.Instance.LoadLevelChooseSection(); });
        gameSelectBtn.onClick.AddListener(() => { LevelManager2.Instance.LoadGameChooseSection(); });
    }
    private void CantDraw()
    {
        LevelManager2.Instance.canDraw = false;
    }
    private void CanDraw()
    {
        LevelManager2.Instance.canDraw = true;
    }
}
