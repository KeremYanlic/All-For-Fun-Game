using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicMapIndexManager : MonoBehaviour
{

    public static SonicMapIndexManager Instance;

    #region SONIC LEVELS
    [SerializeField] private SonicLevelSO sonicLevel1;
    [SerializeField] private SonicLevelSO sonicLevel2;
    [SerializeField] private SonicLevelSO sonicLevel3;
    [SerializeField] private SonicLevelSO sonicLevel4;
    [SerializeField] private SonicLevelSO sonicLevel5;
    [SerializeField] private SonicLevelSO sonicLevel6;
    [SerializeField] private SonicLevelSO sonicLevel7;
    [SerializeField] private SonicLevelSO sonicLevel8;
    [SerializeField] private SonicLevelSO sonicLevel9;
    [SerializeField] private SonicLevelSO sonicLevel10;
    [SerializeField] private SonicLevelSO sonicLevel11;
    [SerializeField] private SonicLevelSO sonicLevel12;
    [SerializeField] private SonicLevelSO sonicLevel13;
    [SerializeField] private SonicLevelSO sonicLevel14;
    [SerializeField] private SonicLevelSO sonicLevel15;
    [SerializeField] private SonicLevelSO sonicLevel16;
    [SerializeField] private SonicLevelSO sonicLevel17;
    [SerializeField] private SonicLevelSO sonicLevel18;
    [SerializeField] private SonicLevelSO sonicLevel19;
    [SerializeField] private SonicLevelSO sonicLevel20;
    [SerializeField] private SonicLevelSO sonicLevel21;
    [SerializeField] private SonicLevelSO sonicLevel22;
    [SerializeField] private SonicLevelSO sonicLevel23;
    [SerializeField] private SonicLevelSO sonicLevel24;
    [SerializeField] private SonicLevelSO sonicLevel25;
    [SerializeField] private SonicLevelSO sonicLevel26;
    [SerializeField] private SonicLevelSO sonicLevel27;
    [SerializeField] private SonicLevelSO sonicLevel28;
    [SerializeField] private SonicLevelSO sonicLevel29;
    [SerializeField] private SonicLevelSO sonicLevel30;
    #endregion

    public int sonicMapIndex;
    private void Awake()
    {
        Instance = this;

        sonicMapIndex = PlayerPrefs.GetInt("sonicLevel", 1);
    }
    public SonicLevelSO GetSonicLevel(int SonicMapIndex)
    {
        if(SonicMapIndex == 1)
        {
            return sonicLevel1;
        }
        else if (SonicMapIndex == 2)
        {
            return sonicLevel2;
        }
        else if (SonicMapIndex == 3)
        {
            return sonicLevel3;
        }
        else if (SonicMapIndex == 4)
        {
            return sonicLevel4;
        }
        else if (SonicMapIndex == 5)
        {
            return sonicLevel5;
        }
        else if (SonicMapIndex == 6)
        {
            return sonicLevel6;
        }
        else if (SonicMapIndex == 7)
        {
            return sonicLevel7;
        }
        else if (SonicMapIndex == 8)
        {
            return sonicLevel8;
        }
        else if (SonicMapIndex == 9)
        {
            return sonicLevel9;
        }
        else if (SonicMapIndex == 10)
        {
            return sonicLevel10;
        }
        else if (SonicMapIndex == 11)
        {
            return sonicLevel11;
        }
        else if (SonicMapIndex == 12)
        {
            return sonicLevel12;
        }
        else if (SonicMapIndex == 13)
        {
            return sonicLevel13;
        }
        else if (SonicMapIndex == 14)
        {
            return sonicLevel14;
        }
        else if (SonicMapIndex == 15)
        {
            return sonicLevel15;
        }
        else if (SonicMapIndex == 16)
        {
            return sonicLevel16;
        }
        else if (SonicMapIndex == 17)
        {
            return sonicLevel17;
        }
        else if (SonicMapIndex == 18)
        {
            return sonicLevel18;
        }
        else if (SonicMapIndex == 19)
        {
            return sonicLevel19;
        }
        else if (SonicMapIndex == 20)
        {
            return sonicLevel20;
        }
        else if (SonicMapIndex == 21)
        {
            return sonicLevel21;
        }
        else if (SonicMapIndex == 22)
        {
            return sonicLevel22;
        }
        else if (SonicMapIndex == 23)
        {
            return sonicLevel23;
        }
        else if (SonicMapIndex == 24)
        {
            return sonicLevel24;
        }
        else if (SonicMapIndex == 25)
        {
            return sonicLevel25;
        }
        else if (SonicMapIndex == 26)
        {
            return sonicLevel26;
        }
        else if (SonicMapIndex == 27)
        {
            return sonicLevel27;
        }
        else if (SonicMapIndex == 28)
        {
            return sonicLevel28;
        }
        else if (SonicMapIndex == 29)
        {
            return sonicLevel29;
        }
        else if (SonicMapIndex == 30)
        {
            return sonicLevel30;
        }

        return null;
    }

    public int GetCurrentLevelIndex()
    {
        return sonicMapIndex;
    }
    public void IncreaseLevelIndex()
    {
        sonicMapIndex++;
    }
    private void OnApplicationQuit()
    {
        sonicMapIndex = 1;
        PlayerPrefs.SetInt("sonicLevel", 1);
    }
}
