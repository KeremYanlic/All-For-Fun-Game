using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SonicMMM : MonoBehaviour
{
    private Button gameChooseBtn;
    private TextMeshProUGUI chooseLevelText;

    private void Awake()
    {
        Definitions();
        LeanTweenAnims();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Definitions()
    {
        #region Define Variables
        gameChooseBtn = transform.Find("gameChooseBtn").GetComponent<Button>();
        chooseLevelText = transform.Find("chooseLevelText").GetComponent<TextMeshProUGUI>();
        #endregion
    }
    private void LeanTweenAnims()
    {
        LeanTweenScale(gameChooseBtn.gameObject, new Vector3(1f, 1f,1f), 1f);
        LeanTweenScale(chooseLevelText.gameObject, new Vector3(1f, 1f,1f), 1f);

    }

    private void LeanTweenScale(GameObject objectToScale,Vector3 size,float scaleSpeed)
    {
        LeanTween.scale(objectToScale, size, scaleSpeed).setEaseInBounce();
    }
}
