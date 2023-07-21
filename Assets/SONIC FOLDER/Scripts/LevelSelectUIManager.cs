using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelSelectUIManager : MonoBehaviour
{
    private Image lockImage;
    private Image openImage;

    public List<Image> LevelButtons;

    private Button menuBtn;
    // Start is called before the first frame update

    private void Awake()
    {
        for(int i = 0; i < LevelButtons.Count; i++)
        {
            LeanTweenScale(LevelButtons[i].gameObject, new Vector3(1f, 1f), 1f);
        }

    
    }
    void Start()
    {
        lockImage = transform.Find("levelLockImage").GetComponent<Image>();
        openImage = transform.Find("levelOpenImage").GetComponent<Image>();


        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < LevelButtons.Count; i++)
        {
            if(i + 1 > levelReached)
            {
                LevelButtons[i].GetComponent<Button>().interactable = false;
                LevelButtons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
                LevelButtons[i].sprite = lockImage.sprite;
            }
            else
            {
                LevelButtons[i].GetComponent<Button>().interactable = true;
                LevelButtons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(true);
                LevelButtons[i].sprite = openImage.sprite;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LeanTweenScale(GameObject levelBtns,Vector3 size,float scaleSpeed)
    {
        LeanTween.scale(levelBtns.gameObject, size, scaleSpeed).setEaseInBounce();
    }
}
