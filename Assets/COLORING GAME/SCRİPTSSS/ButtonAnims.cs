using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonAnims : MonoBehaviour
{
    private Vector2 btnNormalSize;
    private Vector2 firstbtnNormalSize;
    private Vector2 btnBigSize;
    [SerializeField] private float moveSpeed;

    private bool onMouseOver;
    
    private float normalFontSize;
    private float firstNormalSize;
    private float bigFontSize;

   
    private TextMeshProUGUI btnText;
    // Start is called before the first frame update
    private void Awake()
    {
        btnText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        normalFontSize = btnText.fontSize;
        bigFontSize = normalFontSize + 8;
        firstNormalSize = btnText.fontSize;

    }
    void Start()
    {
        btnNormalSize = new Vector2(350, 70);
        btnBigSize = new Vector2(450, 85);
        firstbtnNormalSize = btnNormalSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (!onMouseOver)
        {
            btnNormalSize = Vector2.Lerp(btnNormalSize, firstbtnNormalSize, moveSpeed * Time.deltaTime); // button
            gameObject.GetComponent<RectTransform>().sizeDelta = btnNormalSize;

            normalFontSize = Mathf.Lerp(normalFontSize, firstNormalSize, moveSpeed * Time.deltaTime); // text  

            btnText.fontSize = normalFontSize;
        }

    }
    private void OnMouseOver()
    {
        onMouseOver = true;
        btnNormalSize = Vector2.Lerp(btnNormalSize, btnBigSize, moveSpeed * Time.deltaTime); // button
        gameObject.GetComponent<RectTransform>().sizeDelta = btnNormalSize;

        normalFontSize = Mathf.Lerp(normalFontSize, bigFontSize, moveSpeed * Time.deltaTime); // text
        btnText.fontSize = normalFontSize;
                   
    }
    private void OnMouseExit()
    {
        onMouseOver = false;
 
    }
    
}
