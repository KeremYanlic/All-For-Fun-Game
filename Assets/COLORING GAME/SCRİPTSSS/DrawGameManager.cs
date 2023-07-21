using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGameManager : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {
        GameMonetize.OnResumeGame += ResumeGame;
        GameMonetize.OnPauseGame += PauseGame;
    }
    void Start()
    {
#if UNITY_WEBGL
        ShowAd();
#endif
    }

   

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }


    public void ShowAd()
    {
        GameMonetize.Instance.ShowAd();

    }
}
