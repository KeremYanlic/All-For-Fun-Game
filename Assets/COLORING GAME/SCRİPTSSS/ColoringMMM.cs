using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ColoringMMM : MonoBehaviour
{
    public static ColoringMMM Instance;
    private Button firstImage;
    private Button secondImage;
    private Button thirdImage;
    private Button fourthImage;
    private Button gameSelectBtn;
    private TextMeshProUGUI gameSelectText;

    private Image firstFilter;
    private Image secondFilter;
    private Image thirdFilter;
    private Image fourthFilter;

    private void Awake()
    {
        Instance = this;


        #region First Arrangements
        DefinitionPart();
        OnClickEvents();

        #endregion
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DefinitionPart()
    {
        #region DEFINITIONS
        firstImage = transform.Find("firstImage").GetComponent<Button>();
        secondImage = transform.Find("secondImage").GetComponent<Button>();
        thirdImage = transform.Find("thirdImage").GetComponent<Button>();
        fourthImage = transform.Find("fourthImage").GetComponent<Button>();
        gameSelectBtn = transform.Find("gameSelectBtn").GetComponent<Button>();
        gameSelectText = transform.Find("gameSelectText").GetComponent<TextMeshProUGUI>();

        firstFilter = transform.Find("firstFilter").GetComponent<Image>();
        secondFilter = transform.Find("secondFilter").GetComponent<Image>();
        thirdFilter = transform.Find("thirdFilter").GetComponent<Image>();
        fourthFilter = transform.Find("fourthFilter").GetComponent<Image>();
        #endregion
    }
    public void LeanTweenScaleAnim()
    {
        #region Scale Anims
        LeanTweenScale(firstImage.gameObject, new Vector3(1f, 1f), 1f);
        LeanTweenScale(secondImage.gameObject, new Vector3(1f, 1f), 1f);
        LeanTweenScale(thirdImage.gameObject, new Vector3(1f, 1f), 1f);
        LeanTweenScale(fourthImage.gameObject, new Vector3(1f, 1f), 1f);
        LeanTweenScale(gameSelectBtn.gameObject, new Vector3(1f, 1f), 1f);
        LeanTweenScale(gameSelectText.gameObject, new Vector3(1f, 1f), 1f);

        LeanTweenScale(firstFilter.gameObject, new Vector3(1f, 1f), 1f);
        LeanTweenScale(secondFilter.gameObject, new Vector3(1f, 1f), 1f);
        LeanTweenScale(thirdFilter.gameObject, new Vector3(1f, 1f), 1f);
        LeanTweenScale(fourthFilter.gameObject, new Vector3(1f, 1f), 1f);
        #endregion
    }


    private void LeanTweenScale(GameObject objectToScale,Vector3 sizeToScale,float scaleSpeed)
    {
        LeanTween.scale(objectToScale, sizeToScale, scaleSpeed).setEaseInOutBack();
    }

    private void OnClickEvents()
    {
        firstImage.onClick.AddListener(() => { LevelManager.Instance.OpeningFirstScene(); });
        secondImage.onClick.AddListener(() => { LevelManager.Instance.OpeningSecondScene(); });
        thirdImage.onClick.AddListener(() => { LevelManager.Instance.OpeningThirdScene(); });
        fourthImage.onClick.AddListener(() => { LevelManager.Instance.OpeningFourthScene(); });
        gameSelectBtn.onClick.AddListener(() => { LevelManager.Instance.LoadGameSelectMenu(); });
    }

}
