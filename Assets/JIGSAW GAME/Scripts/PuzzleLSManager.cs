using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PuzzleLSManager : MonoBehaviour
{
    private GameObject leftArray;
    private GameObject middleArray;
    private GameObject rightArray;
    private Button rightBtn;
    private Button leftBtn;
    private TextMeshProUGUI chooseLevelText;
    
    private Button gameChooseBtn;


    private GameObject currentArray;
    [SerializeField] private float leftX = -1600;
    [SerializeField] private float rightX = 1900;
    [SerializeField] private float sceneX = 0;
    [SerializeField] private float dragSpeed;
    // Start is called before the first frame update
    void Start()
    {
        leftArray = transform.Find("leftArray").gameObject;
        middleArray = transform.Find("middleArray").gameObject;
        rightArray = transform.Find("rightArray").gameObject;

        rightBtn = transform.Find("rightBtn").GetComponent<Button>();
        leftBtn = transform.Find("leftBtn").GetComponent<Button>();

        chooseLevelText = transform.Find("ChooseLevelText").GetComponent<TextMeshProUGUI>();
       

        gameChooseBtn = transform.Find("gameChooseBtn").GetComponent<Button>();

        currentArray = leftArray;
        

        rightBtn.onClick.AddListener(() =>
        {
            if (currentArray == leftArray) { currentArray = middleArray; DragArray(leftArray, leftX); DragArray(middleArray, sceneX); }
            else if (currentArray == middleArray) { currentArray = rightArray; DragArray(middleArray, leftX); DragArray(rightArray, sceneX); }
            else if(currentArray == rightArray) { return; }

        });
        leftBtn.onClick.AddListener(() =>
        {
            if (currentArray == leftArray) { return; }
            else if (currentArray == middleArray) { currentArray = leftArray; DragArray(leftArray, sceneX); DragArray(middleArray, rightX); }
            else if (currentArray == rightArray) { currentArray = middleArray; DragArray(rightArray, rightX); DragArray(middleArray, sceneX); }
        });

      

        LeanTween.scale(chooseLevelText.gameObject, new Vector3(1f, 1f), 1f).setEaseInExpo();
       
        LeanTween.scale(gameChooseBtn.gameObject, new Vector3(1f, 1f), 1f).setEaseInBounce();
    }
   private void DragArray(GameObject array,float xValue)
    {
        LeanTween.moveLocalX(array, xValue, dragSpeed);
    }

}
