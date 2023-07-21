using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonAnims2 : MonoBehaviour
{
    private Vector2 firstNormalSize;
    [SerializeField] private Vector2 normalSize;
    [SerializeField] private Vector2 wantedSize;
    [SerializeField] private float transitionSpeed;
    private bool isMouseOver;

    [SerializeField] private bool isHiddenStarGame = false;
    // Start is called before the first frame update
    void Start()
    {
        firstNormalSize = normalSize;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!isMouseOver)
        {
            if (!isHiddenStarGame)
            {
                normalSize = Vector2.Lerp(normalSize, firstNormalSize, transitionSpeed * Time.deltaTime);
                gameObject.GetComponent<RectTransform>().sizeDelta = normalSize;
            }
            else
            {
                normalSize = Vector2.Lerp(normalSize, firstNormalSize, transitionSpeed * Time.deltaTime);
                gameObject.GetComponent<RectTransform>().sizeDelta = normalSize;
                gameObject.GetComponent<Image>().color = Color.white;
            }
          
        }
    }
    private void OnMouseOver()
    {
        isMouseOver = true;

        if (!isHiddenStarGame)
        {
            normalSize = Vector2.Lerp(normalSize, wantedSize, transitionSpeed * Time.deltaTime);
            gameObject.GetComponent<RectTransform>().sizeDelta = normalSize;
            gameObject.GetComponent<BoxCollider2D>().size += gameObject.GetComponent<RectTransform>().sizeDelta - gameObject.GetComponent<BoxCollider2D>().size;

        }
        else
        {
            normalSize = Vector2.Lerp(normalSize, wantedSize, transitionSpeed * Time.deltaTime);
            gameObject.GetComponent<RectTransform>().sizeDelta = normalSize;
            gameObject.GetComponent<BoxCollider2D>().size += gameObject.GetComponent<RectTransform>().sizeDelta - gameObject.GetComponent<BoxCollider2D>().size;
            gameObject.GetComponent<Image>().color = Color.green;
        }
      
        
      
        



    }
    private void OnMouseExit()
    {
        isMouseOver = false;
    }
}
