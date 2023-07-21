using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDManager : MonoBehaviour
{
    public GameObject SettingMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SettingMenu.gameObject.activeSelf)
        {
            Countdown.Instance.allowToCountDown = false;
            OnPressStar.Instance.canPressStar = false;
        }
        else
        {
            Countdown.Instance.allowToCountDown = true;
            OnPressStar.Instance.canPressStar = true;
        }
    }
    
}
