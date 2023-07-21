using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilAnim : MonoBehaviour
{
    [SerializeField] private float normalHeight = 70f;
    [SerializeField] private float wantedHeight = 100f;


    Vector3 initialPos;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        initialPos = gameObject.GetComponent<RectTransform>().anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = initialPos + new Vector3(0, wantedHeight, 0);
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = initialPos;

    }
   
     
}
