using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageAnims : MonoBehaviour
{
   
    private Vector2 firstNormalSize;
    [SerializeField] private Vector2 normalSize;
    [SerializeField] private Vector2 wantedSize;
    [SerializeField] private float transitionSpeed;
    private bool isMouseOver;
    [SerializeField] private float timeToSetAnimFalse;
    private Vector2 parentVector;
    private Vector2 parentWantedVector;
    private Vector2 parentFirstVector;

    
  
    // Start is called before the first frame update
    void Start()
    {
        parentVector = new Vector2(390, 390);
        parentFirstVector = parentVector;
        parentWantedVector = new Vector2(420, 420);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMouseOver)
        {

            normalSize = Vector2.Lerp(normalSize, firstNormalSize, transitionSpeed * Time.deltaTime);
            gameObject.GetComponent<RectTransform>().sizeDelta = normalSize;


            GameObject parentObject = gameObject.transform.parent.gameObject;
            parentVector = Vector2.Lerp(parentVector, parentFirstVector, transitionSpeed * Time.deltaTime);
            parentObject.GetComponent<RectTransform>().sizeDelta = parentVector;

         
        }
    }

    private void OnMouseOver()
    {
        isMouseOver = true;

        normalSize = Vector2.Lerp(normalSize, wantedSize, transitionSpeed * Time.deltaTime);
        gameObject.GetComponent<RectTransform>().sizeDelta = normalSize;
        gameObject.GetComponent<BoxCollider2D>().size += gameObject.GetComponent<RectTransform>().sizeDelta - gameObject.GetComponent<BoxCollider2D>().size;

        GameObject parentObject = gameObject.transform.parent.gameObject;
        parentVector = Vector2.Lerp(parentVector, parentWantedVector, transitionSpeed * Time.deltaTime);
        parentObject.GetComponent<RectTransform>().sizeDelta = parentVector;



    }
    private void OnMouseExit()
    {
        isMouseOver = false;
    }
}
