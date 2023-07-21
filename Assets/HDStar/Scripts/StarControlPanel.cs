using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class StarControlPanel : MonoBehaviour
{
    public event Action<StarControlPanel, StarControlPanelEventArgs> OnPressStarControlPanel;

    public class StarControlPanelEventArgs : EventArgs
    {
        public int starIndex;
    }

    public void CallPressStarControlPanel(int starIndex)
    {
        OnPressStarControlPanel?.Invoke(this, new StarControlPanelEventArgs() { starIndex = starIndex });
    }


    public static StarControlPanel Instance;



    public Image star;
    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        OnPressStarControlPanel += StarControlPanel_OnPressStarControlPanel; 
    }
    private void OnDisable()
    {
        OnPressStarControlPanel -= StarControlPanel_OnPressStarControlPanel;
    }

    private void InstantiateStarImages()
    {
        for(int i = 0; i< 9; i++)
        {
            Image stars = Instantiate(star, transform);
            stars.GetComponent<RectTransform>().anchoredPosition = new Vector2(-350 + i * 90, 0f);

        }
    }
    private void ClearStarImages()
    {
        foreach(Transform image in transform)
        {
            if(image != null)
            {
                Destroy(image.gameObject);
            }
        }
    }

    public void StarControlPanelProcess()
    {

        ClearStarImages();

        InstantiateStarImages();
    }

    private void StarControlPanel_OnPressStarControlPanel(StarControlPanel starControlPanel,StarControlPanelEventArgs starControlPanelEventArgs)
    {
        transform.GetChild(starControlPanelEventArgs.starIndex).GetComponent<Image>().color = DefineFullOpacityColor();
    }
    private Color DefineFullOpacityColor()
    {
        return HSUtilsClass.FullOpacity(255f, 255f, 0f, 255f);
    }

}
