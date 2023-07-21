using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SonicGameManager : MonoBehaviour
{
    public static SonicGameManager Instance;

    public event Action<SonicGameManager, CurrentLevelVariablesEventArgs> SetCurrentLevelVariables;

    public class CurrentLevelVariablesEventArgs: EventArgs
    {
        public SonicLevelSO currentSonicLevel;
      
    }
    [SerializeField] private GameObject portalPrefab;
    [SerializeField] private GameObject portalPrefabWithPlatform;
    [SerializeField] private Vector3 portalSpawnPos;
    [SerializeField] private GameObject player;
    [SerializeField] private float brokenPlatformDestroyTime;
    [SerializeField] private bool isPortalHasPlatform;
    
    public int sceneCoinCount;

    private SonicLevelSO currentSonicLevel;
    private int mapIndex;
    private void Awake()
    {
        Instance = this;

        
    }
    private void OnEnable()
    {
        SetCurrentLevelVariables += SonicGameManager_SetCurrentLevelVariables;
    }

   

    private void OnDisable()
    {
        SetCurrentLevelVariables -= SonicGameManager_SetCurrentLevelVariables;
    }


    private void Start()
    {
        BuildMap(SonicMapIndexManager.Instance.sonicMapIndex);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("levelReached", 1);
    }
    
    public void BuildMap(int mapIndex)
    {
        if(mapIndex >= 1 && mapIndex <= 30)
        {
            currentSonicLevel = SonicMapIndexManager.Instance.GetSonicLevel(mapIndex);

            MapBuilder.Instance.ClearContainers();

            SetPlayerPosition();

            CallSetCurrentLevelVariablesEvent(currentSonicLevel);
            
            MapBuilder.Instance.BuildingLevel(currentSonicLevel);

           
        }
    }

    private void SonicGameManager_SetCurrentLevelVariables(SonicGameManager sonicGameManager, CurrentLevelVariablesEventArgs currentLevelVariablesEventArgs)
    {
        sceneCoinCount = currentLevelVariablesEventArgs.currentSonicLevel.goldCoinAmount;
        isPortalHasPlatform = currentLevelVariablesEventArgs.currentSonicLevel.isPortalHasPlatform;
        portalSpawnPos = new Vector3(currentLevelVariablesEventArgs.currentSonicLevel.portalPosition.x, currentLevelVariablesEventArgs.currentSonicLevel.portalPosition.y, 0f);
        brokenPlatformDestroyTime = currentLevelVariablesEventArgs.currentSonicLevel.brokenPlatformDestroyTime;

        PlayerEvents.Instance.CallOnMapChangedEvent(
            sceneCoinCount,
            isPortalHasPlatform,
            portalSpawnPos,
            brokenPlatformDestroyTime
            );
    }

    private SonicLevelSO CallSetCurrentLevelVariablesEvent(SonicLevelSO currentSonicLevel)
    {
        SetCurrentLevelVariables?.Invoke(this, new CurrentLevelVariablesEventArgs() { currentSonicLevel = currentSonicLevel });

        return currentSonicLevel;
    }


    public GameObject GetPortalPrefab()
    {
        return portalPrefab;
    }
    public GameObject GetPortalPrefabWithPlatform()
    {
        return portalPrefabWithPlatform;
    }
    public Vector3 GetPortalSpawnPosition()
    {
        return portalSpawnPos;
    }
    public int GetCoinAmount()
    {
        return sceneCoinCount;
    }
    private void SetPlayerPosition()
    {
        player.transform.position = new Vector3(-10.5f, -3.3f, 0f);
        player.transform.localScale = new Vector3(1, 1, 1);
    }
}
