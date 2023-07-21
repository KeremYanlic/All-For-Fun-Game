using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleSM : MonoBehaviour
{
    public static PuzzleSM Instance;


    private Button restartBtn;
    private Button menuBtn;
   

    [SerializeField] private float growSpeed;

    private bool canShuffle;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        restartBtn = transform.Find("restartBtn").GetComponent<Button>();
        menuBtn = transform.Find("menuBtn").GetComponent<Button>();

        LeanTween.scale(menuBtn.gameObject, new Vector3(0.8f, 0.8f), growSpeed).setDelay(.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(restartBtn.gameObject, new Vector3(0.8f , 0.8f), growSpeed).setDelay(.5f).setEase(LeanTweenType.easeOutElastic).setOnComplete(SetShuffleTrue);

        Invoke(nameof(SetShuffleFalse), 3f);


        restartBtn.onClick.AddListener(() => { PuzzleManager.Instance.RestartLevel(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetShuffleTrue()
    { 
        canShuffle = true;
    }
    private void SetShuffleFalse()
    {
        canShuffle = false;
    }
    public bool GetCanShuffleBool()
    {
        return canShuffle;
    }
}
