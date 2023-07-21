using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

  

public class DrawMeshUI : MonoBehaviour {



    DrawMeshFull drawMeshFull;
    private void Awake() {

    

        drawMeshFull = FindObjectOfType<DrawMeshFull>();
        transform.Find("Thickness1Btn").GetComponent<Button>().onClick.AddListener(() => { SetThickness(0.2f); });
        transform.Find("Thickness2Btn").GetComponent<Button>().onClick.AddListener(() => { SetThickness(0.6f); });
        transform.Find("Thickness3Btn").GetComponent<Button>().onClick.AddListener(() => { SetThickness(1f); });
        transform.Find("Thickness4Btn").GetComponent<Button>().onClick.AddListener(() => { SetThickness(2f); });

      //  transform.Find("bluecolor").GetComponent<Button>().onClick.AddListener(() => { SetColor(DrawMeshFull.Instance.GetColorFromString("00C2FF")); SetColorAlpha(1f); drawMeshFull.BrushColor.gameObject.SetActive(true); drawMeshFull.brushColor = Color.blue; drawMeshFull.Eraser.gameObject.SetActive(false); });
      //  transform.Find("darkcolor").GetComponent<Button>().onClick.AddListener(() => { SetColor(DrawMeshFull.Instance.GetColorFromString("010203")); SetColorAlpha(1f); drawMeshFull.BrushColor.gameObject.SetActive(true);  drawMeshFull.brushColor = Color.black; drawMeshFull.Eraser.gameObject.SetActive(false); });
      //  transform.Find("browncolor").GetComponent<Button>().onClick.AddListener(() => { SetColor(DrawMeshFull.Instance.GetColorFromString("762600")); SetColorAlpha(1f); drawMeshFull.BrushColor.gameObject.SetActive(true); drawMeshFull.brushColor.r = 1; drawMeshFull.brushColor.g = 0.6f; drawMeshFull.brushColor.b = 0; drawMeshFull.Eraser.gameObject.SetActive(false); });
      //  transform.Find("skincolor").GetComponent<Button>().onClick.AddListener(() => { SetColor(DrawMeshFull.Instance.GetColorFromString("FFAE8B")); SetColorAlpha(1f); drawMeshFull.BrushColor.gameObject.SetActive(true); drawMeshFull.brushColor.r = 0.9f; drawMeshFull.brushColor.g = 0.74f; drawMeshFull.brushColor.b = 0.67f; drawMeshFull.Eraser.gameObject.SetActive(false); });
      //  transform.Find("greencolor").GetComponent<Button>().onClick.AddListener(() => { SetColor(DrawMeshFull.Instance.GetColorFromString("00FF00")); SetColorAlpha(1f); drawMeshFull.BrushColor.gameObject.SetActive(true); drawMeshFull.brushColor = Color.green; drawMeshFull.Eraser.gameObject.SetActive(false); });
      //  transform.Find("orangecolor").GetComponent<Button>().onClick.AddListener(() => { SetColor(DrawMeshFull.Instance.GetColorFromString("FF6C00")); SetColorAlpha(1f); drawMeshFull.BrushColor.gameObject.SetActive(true); drawMeshFull.brushColor.r = 1; drawMeshFull.brushColor.g = 0.54f; drawMeshFull.brushColor.b = 0; drawMeshFull.Eraser.gameObject.SetActive(false); });
      //  transform.Find("pinkcolor").GetComponent<Button>().onClick.AddListener(() => { SetColor(DrawMeshFull.Instance.GetColorFromString("FF0080")); SetColorAlpha(1f); drawMeshFull.BrushColor.gameObject.SetActive(true); drawMeshFull.brushColor.r = 1; drawMeshFull.brushColor.g = 0.41f; drawMeshFull.brushColor.b = 0.71f; drawMeshFull.Eraser.gameObject.SetActive(false); });
      //  transform.Find("purplecolor").GetComponent<Button>().onClick.AddListener(() => { SetColor(DrawMeshFull.Instance.GetColorFromString("EB00FF")); SetColorAlpha(1f); drawMeshFull.BrushColor.gameObject.SetActive(true); drawMeshFull.brushColor.r = 0.62f; drawMeshFull.brushColor.g = 0.16f; drawMeshFull.brushColor.b = 0.4f; drawMeshFull.Eraser.gameObject.SetActive(false); });
      //  transform.Find("redcolor").GetComponent<Button>().onClick.AddListener(() => { SetColor(DrawMeshFull.Instance.GetColorFromString("FF0000")); SetColorAlpha(1f); drawMeshFull.BrushColor.gameObject.SetActive(true); drawMeshFull.brushColor = Color.red; drawMeshFull.Eraser.gameObject.SetActive(false); });
      //  transform.Find("yellowcolor").GetComponent<Button>().onClick.AddListener(() => { SetColor(DrawMeshFull.Instance.GetColorFromString("FFFF00")); SetColorAlpha(1f); drawMeshFull.BrushColor.gameObject.SetActive(true); drawMeshFull.brushColor = Color.yellow; drawMeshFull.Eraser.gameObject.SetActive(false); });
      //  transform.Find("bluegreencolor").GetComponent<Button>().onClick.AddListener(() => { SetColor(DrawMeshFull.Instance.GetColorFromString("00FFAC")); SetColorAlpha(1f); drawMeshFull.BrushColor.gameObject.SetActive(true); drawMeshFull.brushColor.r = 0; drawMeshFull.brushColor.g = 1f; drawMeshFull.brushColor.b = 0.7f; drawMeshFull.Eraser.gameObject.SetActive(false); });
      //  transform.Find("darkblueColor").GetComponent<Button>().onClick.AddListener(() => { SetColor(DrawMeshFull.Instance.GetColorFromString("000CFF")); SetColorAlpha(1f); drawMeshFull.BrushColor.gameObject.SetActive(true); drawMeshFull.brushColor.r = 0.1f; drawMeshFull.brushColor.g = 1f; drawMeshFull.brushColor.b = 1f; drawMeshFull.Eraser.gameObject.SetActive(false); });
      //  transform.Find("eraser").GetComponent<Button>().onClick.AddListener(() => { SetColor(DrawMeshFull.Instance.GetColorFromString("CDC0A5")); drawMeshFull.BrushColor.gameObject.SetActive(false); drawMeshFull.Eraser.gameObject.SetActive(true); });
        transform.Find("stepBack").GetComponent<Button>().onClick.AddListener(() => { if (drawMeshFull.AllGameObjects.Count == 0) { return; } Destroy(drawMeshFull.AllGameObjects[drawMeshFull.index - 1]); drawMeshFull.AllGameObjects.RemoveAt(drawMeshFull.index - 1); drawMeshFull.index--; });
        
    }



    private void SetThickness(float thickness) {
        DrawMeshFull.Instance.SetThickness(thickness);
    }

    private void SetColor(Color color) {
        DrawMeshFull.Instance.SetColor(color);
       
    }
    private void SetColorAlpha(float alpha)
    {
        DrawMeshFull.Instance.SetColorAlpha(alpha);
    }
}